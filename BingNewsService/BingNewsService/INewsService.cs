using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace BingNewsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsService" in both code and config file together.
    [ServiceContract]
    public interface INewsService
    {
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{keyword}")]
        List<NewsResult> JSONData(string keyWord);
    }

    public partial class NewsResult
    {

        private Guid _ID;

        private String _Title;

        private String _Url;

        private String _Source;

        private String _Description;

        private DateTime? _Date;

        public Guid ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

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

        public String Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        public String Source
        {
            get
            {
                return this._Source;
            }
            set
            {
                this._Source = value;
            }
        }

        public String Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public DateTime? Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this._Date = value;
            }
        }
    }
}
