using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VS15 {
    //
    public delegate void NewIssueAvailableEvent(object sender, NewIssueAvailableEventArgs e);

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MagazineService:IMagazineService {
        //Members
        public static event NewIssueAvailableEvent NewIssueAvailable;

        private IClientContract callback = null;        //Callback to individual clients using the ClientContract
        private NewIssueAvailableEvent newIssueHandler;

        public void PublishMagazine(string issueLink, string issueNumber, DateTime published) {
            //
            try {
                NewIssueAvailableEventArgs e = new NewIssueAvailableEventArgs();
                e.hyperlinkURL = issueLink;
                e.issueNumber = issueNumber;
                e.datePublished = published;

                NewIssueAvailable(this, e);
            }
            catch (Exception ex) { throw new FaultException<MagazineFault>(new MagazineFault(ex.Message), "Service Error"); }
        }

        public void Subscribe() {
            //
            callback = OperationContext.Current.GetCallbackChannel<IClientContract>();
            newIssueHandler = new NewIssueAvailableEvent(OnNewIssueAvailable);
            NewIssueAvailable += newIssueHandler;
        }
        public void Unsubscribe() {
            //
            NewIssueAvailable -= newIssueHandler;
        }

        public void OnNewIssueAvailable(object sender, NewIssueAvailableEventArgs e) {
            //
            callback.MessageReceived(e.hyperlinkURL, e.issueNumber, e.datePublished);
        }
    }
}
