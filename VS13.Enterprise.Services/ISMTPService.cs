using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VS13 {
    //
    [ServiceContract(Namespace = "http://VS13")]
    public interface ISMTPService {
        //

        [OperationContract]
        [FaultContractAttribute(typeof(SMTPFault),Action = "http://VS13.SMTPFault")]
        void SendMailMessage(string fromEmailAddress,string toEmailAddress,string subject,bool isBodyHtml,string body);

        [OperationContract(Name = "SendMailMessageWithBlindCopy")]
        [FaultContractAttribute(typeof(SMTPFault),Action = "http://VS13.SMTPFault")]
        void SendMailMessage(string fromEmailAddress,string toEmailAddress,string subject,bool isBodyHtml,string body,string bccEmailAddress);
    }

    [DataContract]
    public class SMTPFault {
        private string mMessage = "";
        public SMTPFault(string message) { this.mMessage = message; }
        [DataMember]
        public string Message { get { return this.mMessage; } set { this.mMessage = value; } }
    }
}
