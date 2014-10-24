using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bing;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str;
            
            str = TextBox1.Text.ToString();
            VIdLookUp.Service1Client prox = new VIdLookUp.Service1Client();
             List<VideoResult> res = new List<VideoResult>();
             TryIt.VIdLookUp.VideoResult[] sd = prox.VidLookUp(str);

             VideoResult videoObj = new VideoResult();
             foreach (TryIt.VIdLookUp.VideoResult Test in sd)
             {
                 videoObj = new VideoResult();
                 videoObj.DisplayUrl = Test.DisplayUrl.ToString();
                 videoObj.Title = Test.Title.ToString();
                 res.Add(videoObj);
             }



            
          /*  List<VideoResult> VidresStorage = new List<VideoResult>();



             VideoResult vidResObj = new VideoResult();
             string rootUri = "https://api.datamarket.azure.com/Bing/Search";

             var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));

             // Replace this value with your account key.

             var accountKey = "grSrblWUETXeqmBqJMCK0TOcvL5pUwd15yQhWtgk7wI";
             string market = "en-us";
             // Configure bingContainer to use your credentials.

             bingContainer.Credentials = new System.Net.NetworkCredential(accountKey, accountKey);
             var videoQuery = bingContainer.Video(str, null, market, null, null, null, null, null);
             videoQuery = videoQuery.AddQueryOption("$top", 10);
             var videoResults = videoQuery.Execute();

             foreach (var result in videoResults)
             {

                 vidResObj = new VideoResult();
                 vidResObj.DisplayUrl = result.DisplayUrl;
                 vidResObj.Title = result.Title;
                 VidresStorage.Add(vidResObj);

             }*/


              Label5.Text = res[1].Title.ToString();
           HyperLink1.Text=res[1].DisplayUrl.ToString();

              HyperLink1.NavigateUrl = res[1].DisplayUrl.ToString();


              Label6.Text = res[2].Title.ToString();
              HyperLink2.Text = res[2].DisplayUrl.ToString();

              HyperLink2.NavigateUrl = res[2].DisplayUrl.ToString();

              Label7.Text = res[3].Title.ToString();
              HyperLink3.Text = res[3].DisplayUrl.ToString();

              HyperLink3.NavigateUrl = res[3].DisplayUrl.ToString();


              Label8.Text = res[4].Title.ToString();
              HyperLink4.Text = res[4].DisplayUrl.ToString();

              HyperLink4.NavigateUrl = res[4].DisplayUrl.ToString();

              Label9.Text = res[5].Title.ToString();
              HyperLink5.Text = res[5].DisplayUrl.ToString();

              HyperLink5.NavigateUrl = res[5].DisplayUrl.ToString();

             
         
         

            
        }
    }

    public partial class VideoResult
    {

       // private Guid _ID;

        private String _Title;

       // private String _MediaUrl;

        private String _DisplayUrl;

     //   private Int32? _RunTime;

      //  private Thumbnail _Thumbnail;

       /* public Guid ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }*/

        public String Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

     /*   public String MediaUrl
        {
            get
            {
                return this._MediaUrl;
            }
            set
            {
                this._MediaUrl = value;
            }
        }
        */
        public String DisplayUrl
        {
            get
            {
                return this._DisplayUrl;
            }
            set
            {
                this._DisplayUrl = value;
            }
        }

     /*   public Int32? RunTime
        {
            get
            {
                return this._RunTime;
            }
            set
            {
                this._RunTime = value;
            }
        }

        public Thumbnail Thumbnail
        {
            get
            {
                return this._Thumbnail;
            }
            set
            {
                this._Thumbnail = value;
            }
        }*/
    }
}
