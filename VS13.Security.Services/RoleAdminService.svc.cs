using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace VS13.Security {
    //
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RoleAdminService:IRoleAdminService {
        //Members

        //Interface
        public RoleAdminService() { }

        public Guid GetApplicationID(string applicationName) {
            //Get the ID of for specified applicationName
            Guid id = new Guid();
            try {
                id = new RoleServicesGateway().GetApplicationID(applicationName);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return id;
        }
        public DataSet GetUsers(string applicationName) {
            //Get a list of all users
            DataSet users = new DataSet();
            try {
                DataSet ds = new RoleServicesGateway().GetUsers(applicationName);
                if (ds != null) users.Merge(ds);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return users;
        }
        public Guid CreateUser(string applicationName,string userName) {
            //Create a new user
            Guid userID = new Guid();
            try {
                userID = new RoleServicesGateway().CreateUser(applicationName,userName);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return userID;
        }
        public int DeleteUser(string applicationName,string userName) {
            //Delete an existing user
            int numTablesDeletedFrom = 0;
            try {
                numTablesDeletedFrom = new RoleServicesGateway().DeleteUser(applicationName,userName);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return numTablesDeletedFrom;
        }

        public DataSet GetRoles(string applicationName) {
            //Get a list of all roles
            DataSet roles = new DataSet();
            try {
                DataSet ds = new RoleServicesGateway().GetRoles(applicationName);
                if (ds != null) roles.Merge(ds);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return roles;
        }
        public DataSet GetRolesForUser(string applicationName,string userName) {
            //
            DataSet roles = new DataSet();
            try {
                DataSet ds = new RoleServicesGateway().GetRolesForUser(applicationName,userName);
                if (ds != null) roles.Merge(ds);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return roles;
        }
        public bool AddUserToRole(string applicationName,string userName,string roleName) {
            //
            bool added = false;
            try {
                added = new RoleServicesGateway().AddUserToRole(applicationName,userName,roleName);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return added;
        }
        public bool RemoveUserFromRole(string applicationName,string userName,string roleName) {
            //
            bool removed = false;
            try {
                removed = new RoleServicesGateway().RemoveUserFromRole(applicationName,userName,roleName);
            }
            catch (Exception ex) { throw new FaultException<SecurityFault>(new SecurityFault(ex.Message),"Service Error"); }
            return removed;
        }
    }
}
