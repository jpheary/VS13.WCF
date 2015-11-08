using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace VS13.Prototype {
    //
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.NotAllowed)]
    public class ApplicationService:IApplicationService {
        //Members

        //Interface
        public ApplicationService() { }

        public ServiceInfo GetServiceInfo() {
            //Get service information
            return new VS13.AppService(ApplicationGateway.SQL_CONNID).GetServiceInfo();
        }
        public UserConfiguration GetUserConfiguration(string application,string[] usernames) {
            //Get configuration data for the specified application and usernames
            return new VS13.AppService(ApplicationGateway.SQL_CONNID).GetUserConfiguration(application,usernames);
        }
        public void WriteLogEntry(TraceMessage m) {
            //Forward to Enterprise log service
            VS13.Enterprise.TraceMessage message = new VS13.Enterprise.TraceMessage();
            message.Name = m.Name;
            message.Source = m.Source;
            message.User = m.User;
            message.Computer = m.Computer;
            message.LogLevel = (VS13.Enterprise.LogLevel)m.LogLevel;
            message.Message = m.Message;
            new ExceptionGateway().WriteLogEntry(message);
        }

        [PrincipalPermission(SecurityAction.Demand,Role = "Administrator")]
        public string Echo(string statement) { return statement; }

        public string GetWindowsIdentity() {
            //Get the credentials of the client
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
        //public System.Net.ICredentials GetDefaultCredentials() {
        //    //Get the credentials of the client
        //    return System.Net.CredentialCache.DefaultCredentials;
        //}
        public string GetDefaultNetworkCredentials() {
            //Get the credentials of the client
            return System.Net.CredentialCache.DefaultNetworkCredentials.UserName;
        }
        public string GetHttpContextCurrentUser() {
            //Get the credentials of the client
            return System.Web.HttpContext.Current != null ? System.Web.HttpContext.Current.User.Identity.Name : "No current context";
        }

    }
}
