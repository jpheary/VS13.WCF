﻿using System;
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
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.NotAllowed)]
    public class AppService:IAppService {
        //Members
        private string mConnectionID="";
        private LogLevel mLogLevelFloor=LogLevel.None;

        private const string USP_SERVICEINFO_READ = "uspAppInfoRead",TBL_LOCALTERMINAL = "TerminalTable";
        private const string USP_APPCONFIG_READ = "uspAppConfigRead",TBL_APPCONFIG = "ConfigTable";
        private const string USP_APPLOG_CREATE = "uspAppLogCreate";

        //Interface
        public AppService(string connectionID) {
            //Constructor
            this.mConnectionID = connectionID;
            this.mLogLevelFloor = (LogLevel)Convert.ToInt32(ConfigurationManager.AppSettings["LogLevelFloor"]);
        }

        public ServiceInfo GetServiceInfo() {
            //Get information about this service
            ServiceInfo info = null;
            try {
                info = new ServiceInfo();
                info.Connection = DatabaseFactory.CreateDatabase(this.mConnectionID).ConnectionStringWithoutCredentials;
                //DataSet ds = new DataService().FillDataset(this.mConnectionID,USP_SERVICEINFO_READ,TBL_LOCALTERMINAL,new object[] { });
                //if(ds!=null && ds.Tables[TBL_LOCALTERMINAL].Rows.Count > 0) {
                //    info.TerminalID = Convert.ToInt32(ds.Tables[TBL_LOCALTERMINAL].Rows[0]["TerminalID"]);
                //    info.Number = ds.Tables[TBL_LOCALTERMINAL].Rows[0]["Number"].ToString().Trim();
                //    info.Description = ds.Tables[TBL_LOCALTERMINAL].Rows[0]["Description"].ToString().Trim();
                //}
                info.TerminalID = 0;
                info.Number = "0";
                info.Description = "No Terminal";
            }
            catch(Exception ex) { throw new FaultException<ConfigurationFault>(new ConfigurationFault(ex.Message),"Unexpected Error"); }
            return info;
        }
        public UserConfiguration GetUserConfiguration(string application,string[] usernames) {
            //Get configuration data for the specified application and usernames
            UserConfiguration config=null;
            try {
                //
                config = new UserConfiguration(application);
                DataSet ds = new DataService().FillDataset(this.mConnectionID,USP_APPCONFIG_READ,TBL_APPCONFIG,new object[] { application });
                if(ds != null && ds.Tables[TBL_APPCONFIG] != null) {
                    for(int i=0;i<ds.Tables[TBL_APPCONFIG].Rows.Count;i++) {
                        string userName = ds.Tables[TBL_APPCONFIG].Rows[i]["PCName"].ToString();
                        string key = ds.Tables[TBL_APPCONFIG].Rows[i]["Key"].ToString();
                        string value = ds.Tables[TBL_APPCONFIG].Rows[i]["Value"].ToString();
                        if(!config.ContainsKey(key)) {
                            if(userName.ToLower() == UserConfiguration.USER_DEFAULT.ToLower())
                                config.Add(key,value);
                            else {
                                for(int j=0;j<usernames.Length;j++) {
                                    if(userName.ToLower() == usernames[j].ToLower())
                                        config.Add(key,value);
                                }
                            }
                        }
                        else {
                            for(int j=0;j<usernames.Length;j++) {
                                if(userName.ToLower() == usernames[j].ToLower())
                                    config[key] = value;
                            }
                        }
                    }
                }
            }
            catch(Exception ex) { throw new FaultException<ConfigurationFault>(new ConfigurationFault(ex.Message),"Unexpected Error"); }
            return config;
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

                    new DataService().ExecuteNonQuery(this.mConnectionID,USP_APPLOG_CREATE,new object[] { m.Name,Convert.ToInt32(m.LogLevel),DateTime.Now,m.Source,category,_event,m.User,m.Computer,keyData1,keyData2,keyData3,message });
                }
            }
            catch { }
        }
    }
}
