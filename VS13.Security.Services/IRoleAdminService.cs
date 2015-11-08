using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VS13.Security {
    //Security Interfaces
    [ServiceContract(Namespace = "http://VS13.Security")]
    public interface IRoleAdminService {
        //
        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        Guid GetApplicationID(string applicationName);
        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        DataSet GetUsers(string applicationName);
        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        Guid CreateUser(string applicationName,string userName);
        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        int DeleteUser(string applicationName,string userName);

        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        DataSet GetRoles(string applicationName);
        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        DataSet GetRolesForUser(string applicationName,string userName);
        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        bool AddUserToRole(string applicationName,string userName,string roleName);
        [OperationContract]
        [FaultContractAttribute(typeof(SecurityFault),Action = "http://VS13.SecurityFault")]
        bool RemoveUserFromRole(string applicationName,string userName,string roleName);
    }

    [DataContract]
    public class SecurityFault {
        private string mMessage = "";
        public SecurityFault(string message) { this.mMessage = message; }
        [DataMember]
        public string Message { get { return this.mMessage; } set { this.mMessage = value; } }
    }

}
