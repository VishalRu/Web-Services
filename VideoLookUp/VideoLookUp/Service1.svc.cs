using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Bing;
using System.Data.Services.Client;
namespace VideoLookUp
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


        public List<VideoResult> VidLookUp(string query)
        {
            List<VideoResult> VidresStorage = new List<VideoResult>();
            VideoResult vidResObj = new VideoResult();
            string rootUri = "https://api.datamarket.azure.com/Bing/Search";

            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));

            // Replace this value with your account key.

            var accountKey = "grSrblWUETXeqmBqJMCK0TOcvL5pUwd15yQhWtgk7wI";
            string market = "en-us";
            // Configure bingContainer to use your credentials.

            bingContainer.Credentials = new System.Net.NetworkCredential(accountKey, accountKey);
            var videoQuery = bingContainer.Video(query, null, market, null, null, null, null, null);
            videoQuery = videoQuery.AddQueryOption("$top", 10);
            var videoResults = videoQuery.Execute();

            foreach (var result in videoResults)
            {

                vidResObj = new VideoResult();
                vidResObj.DisplayUrl = result.DisplayUrl;
                vidResObj.Title = result.Title;
                VidresStorage.Add(vidResObj);

            }




            return VidresStorage;
        }
    }
    }

