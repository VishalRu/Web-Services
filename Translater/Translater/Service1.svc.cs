using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Web;
using System.Text;

using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

using System.Web;
using System.ServiceModel.Channels;

using System.Threading;


namespace Translater
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public String Translated(string query, string from, string to)
        {

            string str;
            AdmAccessToken admToken;
            string headerValue;
            //Get Client Id and Client Secret from https://datamarket.azure.com/developer/applications/
            //Refer obtaining AccessToken (http://msdn.microsoft.com/en-us/library/hh454950.aspx) 
            AdmAuthentication admAuth = new AdmAuthentication("c4f43fd5-e871-4bcb-b4bc-7ef945d72486", "DyFo5CVeVPn0x3vjcbkI573uMF17tqGI5gaMYLTmVMY=");

            admToken = admAuth.GetAccessToken();
            // Create a header with the access_token property of the returned token
            headerValue = "Bearer " + admToken.access_token;
            // DetectMethod(headerValue);
            str = TranslateMethod(headerValue, query, from, to);
            return str;

        }
        private static void DetectMethod(string authToken)
        {
            System.Console.WriteLine("Enter Text to detect language:");
            string textToDetect = System.Console.ReadLine();
            //Keep appId parameter blank as we are sending access token in authorization header.
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Detect?text=" + textToDetect;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(System.Type.GetType("System.String"));
                    string languageDetected = (string)dcs.ReadObject(stream);
                    System.Console.WriteLine(string.Format("Language detected:{0}", languageDetected));
                    System.Console.WriteLine("Press any key to continue...");
                    System.Console.ReadKey(true);

                }
            }

            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        private static string TranslateMethod(string authToken, string query, string from, string to)
        {
            //string[] res = { };
            //int j = 0;
            // Add TranslatorService as a service reference, Address:http://api.microsofttranslator.com/V2/Soap.svc
            TranslatorService.LanguageServiceClient client = new TranslatorService.LanguageServiceClient();
            //Set Authorization header before sending the request
            HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
            httpRequestProperty.Method = "POST";
            httpRequestProperty.Headers.Add("Authorization", authToken);

            // Creates a block within which an OperationContext object is in scope.
            using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                // string sourceText = "<UL><LI>Use generic class names. <LI>Use pixels to express measurements for padding and margins. <LI>Use percentages to specify font size and line height. <LI>Use either percentages or pixels to specify table and container width.   <LI>When selecting font families, choose browser-independent alternatives.   </LI></UL>";
                string translationResult;
                //Keep appId parameter blank as we are sending access token in authorization header.
                translationResult = client.Translate("", query, from, to, "text/html", "general");
                return translationResult;
                //System.Console.WriteLine("Translation for source {0} from {1} to {2} is", sourceText, "en", "de");
                /*System.Console.WriteLine(translationResult);
                System.Console.WriteLine("Press any key to continue...");
                System.Console.ReadKey(true);*/
            }
        }
    }
    /* private static void ProcessWebException(WebException e)
     {
         System.Console.WriteLine("{0}", e.ToString());
         // Obtain detailed error information
         string strResponse = string.Empty;
         using (HttpWebResponse response = (HttpWebResponse)e.Response)
         {
             using (Stream responseStream = response.GetResponseStream())
             {
                 using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.ASCII))
                 {
                     strResponse = sr.ReadToEnd();
                 }
             }
         }
         System.Console.WriteLine("Http status code={0}, error message={1}", e.Status, strResponse);
     }
 }*/
    [DataContract]
    public class AdmAccessToken
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string expires_in { get; set; }
        [DataMember]
        public string scope { get; set; }
    }

    public class AdmAuthentication
    {
        public static readonly string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
        private string clientId;
        private string clientSecret;
        private string request;
        private AdmAccessToken token;
        private Timer accessTokenRenewer;

        //Access token expires every 10 minutes. Renew it every 9 minutes only.
        private const int RefreshTokenDuration = 9;

        public AdmAuthentication(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            //If clientid or client secret has special characters, encode before sending request
            this.request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));
            this.token = HttpPost(DatamarketAccessUri, this.request);
            //renew the token every specfied minutes
            accessTokenRenewer = new Timer(new TimerCallback(OnTokenExpiredCallback), this, System.TimeSpan.FromMinutes(RefreshTokenDuration), System.TimeSpan.FromMilliseconds(-1));
        }

        public AdmAccessToken GetAccessToken()
        {
            return this.token;
        }


        private void RenewAccessToken()
        {
            AdmAccessToken newAccessToken = HttpPost(DatamarketAccessUri, this.request);
            //swap the new token with old one
            //Note: the swap is thread unsafe
            this.token = newAccessToken;
            System.Console.WriteLine(string.Format("Renewed token for user: {0} is: {1}", this.clientId, this.token.access_token));
        }

        private void OnTokenExpiredCallback(object stateInfo)
        {
            try
            {
                RenewAccessToken();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(string.Format("Failed renewing access token. Details: {0}", ex.Message));
            }
            finally
            {

                accessTokenRenewer.Change(System.TimeSpan.FromMinutes(RefreshTokenDuration), System.TimeSpan.FromMilliseconds(-1));

            }
        }


        private AdmAccessToken HttpPost(string DatamarketAccessUri, string requestDetails)
        {
            //Prepare OAuth request 
            WebRequest webRequest = WebRequest.Create(DatamarketAccessUri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
            webRequest.ContentLength = bytes.Length;
            using (Stream outputStream = webRequest.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
                //Get deserialized object from JSON stream
                AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
                return token;
            }
        }
    }
}
