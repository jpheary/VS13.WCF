using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

//
namespace VS13 {
    //
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class AppService:IAppService {
        //Members
        private string mConnectionID="";
        private LogLevel mLogLevelFloor=LogLevel.None;

        private const string USP_LOG_NEW = "uspAppLogCreate";

        //Interface
        public AppService(string connectionID) {
            //Constructor
            this.mConnectionID = connectionID;
            this.mLogLevelFloor = (LogLevel)Convert.ToInt32(ConfigurationManager.AppSettings["LogLevelFloor"]);
        }

        public void WriteLogEntry(TraceMessage m) {
            //Write o to database log if event level is severe enough
            try {
                if(m.LogLevel >= this.mLogLevelFloor) {
                    string message = (m.Message != null) ? m.Message : "";
                    message = message.Replace("\\n"," ");
                    message = message.Replace("\r","");
                    message = message.Replace("\n","");
                    string category = (m.Category != null) ? m.Category : "";
                    string _event = (m.Event != null) ? m.Event : "";
                    string keyData1 = (m.Keyword1 != null) ? m.Keyword1 : "";
                    string keyData2 = (m.Keyword2 != null) ? m.Keyword2 : "";
                    string keyData3 = (m.Keyword3 != null) ? m.Keyword3 : "";

                    new DataService().ExecuteNonQuery(this.mConnectionID,USP_LOG_NEW,new object[] { m.Name,Convert.ToInt32(m.LogLevel),DateTime.Now,m.Source,category,_event,m.User,m.Computer,keyData1,keyData2,keyData3,message });
                }
            }
            catch { }
        }
    }
}
