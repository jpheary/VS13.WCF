using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VS15 {
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IClientContract), Namespace = "VS15")]
    public interface IMagazineService {
        //Interface
        [OperationContract(IsOneWay = false)]
        [FaultContractAttribute(typeof(MagazineFault), Action = "http://VS15.MagazineFault")]
        void PublishMagazine(string hyperLinkToIssue, string issueNumber, DateTime datePublished);

        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();

        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();
    }

    [DataContract]
    public class MagazineFault {
        private string mMessage = "";
        public MagazineFault(string message) { this.mMessage = message; }
        [DataMember]
        public string Message { get { return this.mMessage; } set { this.mMessage = value; } }
    }

    public interface IClientContract {
        [OperationContract(IsOneWay = false)]
        void MessageReceived(string hyperlinkToNewIssue, string issueNumber, DateTime datePublished);
    }

    public class NewIssueAvailableEventArgs:EventArgs {
        public string hyperlinkURL;
        public string issueNumber;
        public DateTime datePublished;
    }

}
