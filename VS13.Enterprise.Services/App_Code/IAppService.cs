using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VS13 {
    //
    [ServiceContract(Namespace = "http://VS10")]
    public interface IAppService {
        [OperationContract(IsOneWay=true)]
        void WriteLogEntry(TraceMessage m);
    }

    [DataContract]
    public enum LogLevel {
        [EnumMember]
        None,
        [EnumMember]
        Debug,
        [EnumMember]
        Information,
        [EnumMember]
        Warning,
        [EnumMember]
        Error
    }

    [DataContract]
    public class TraceMessage {
        //Members
        private long mID=0;
        private string mName="";
        private DateTime mDate;
        private string mCategory="",mEvent="";
        private string mUser=Environment.UserName,mComputer=Environment.MachineName;
        private string mSource="",mMessage="";
        private LogLevel mLogLevel=LogLevel.None;
        private string mKeyword1="",mKeyword2="",mKeyword3="";

        //Interface
        public TraceMessage(string user,string computer,string message,string source,LogLevel logLevel) : this(user,computer,message,source,logLevel,"","","") { }
        public TraceMessage(string user,string computer,string message,string source,LogLevel logLevel,string keyData1,string keyData2,string keyData3) {
            //Constructor
            this.mUser = user;
            this.mComputer = computer;
            this.mMessage = message;
            this.mSource = source;
            this.mLogLevel = logLevel;
            this.mKeyword1 = keyData1;
            this.mKeyword2 = keyData2;
            this.mKeyword3 = keyData3;
        }
        [DataMember]
        public long ID { get { return this.mID; } set { this.mID = value; } }
        [DataMember]
        public string Name { get { return this.mName; } set { this.mName = value; } }
        [DataMember]
        public DateTime Date { get { return this.mDate; } set { this.mDate = value; } }
        [DataMember]
        public string Category { get { return this.mCategory; } set { this.mCategory = value; } }
        [DataMember]
        public string Event { get { return this.mEvent; } set { this.mEvent = value; } }
        [DataMember]
        public string User { get { return this.mUser; } set { this.mUser = value; } }
        [DataMember]
        public string Computer { get { return this.mComputer; } set { this.mComputer = value; } }
        [DataMember]
        public string Message { get { return this.mMessage; } set { this.mMessage = value; } }
        [DataMember]
        public string Source { get { return this.mSource; } set { this.mSource = value; } }
        [DataMember]
        public LogLevel LogLevel { get { return this.mLogLevel; } set { this.mLogLevel = value; } }
        [DataMember]
        public string Keyword1 { get { return this.mKeyword1; } set { this.mKeyword1 = value; } }
        [DataMember]
        public string Keyword2 { get { return this.mKeyword2; } set { this.mKeyword2 = value; } }
        [DataMember]
        public string Keyword3 { get { return this.mKeyword3; } set { this.mKeyword3 = value; } }
    }
}
