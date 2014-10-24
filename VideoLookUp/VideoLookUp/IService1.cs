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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

           [OperationContract]
        List<VideoResult> VidLookUp(string query);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


    public partial class VideoResult
    {

        private Guid _ID;

        private String _Title;

        private String _MediaUrl;

        private String _DisplayUrl;

        private Int32? _RunTime;

        private Thumbnail _Thumbnail;

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

        public String MediaUrl
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

        public Int32? RunTime
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
        }
    }
}
