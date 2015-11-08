using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VS13.Prototype {
    //Shipping Interfaces
    [ServiceContract(Namespace = "http://VS13.Prototype")]
    public interface IApplicationService {
        //
        [OperationContract]
        [FaultContractAttribute(typeof(ConfigurationFault),Action = "http://VS13.ConfigurationFault")]
        ServiceInfo GetServiceInfo();

        [OperationContract]
        [FaultContractAttribute(typeof(ConfigurationFault),Action = "http://VS13.ConfigurationFault")]
        UserConfiguration GetUserConfiguration(string application,string[] usernames);

        [OperationContract(IsOneWay = true)]
        void WriteLogEntry(TraceMessage m);

        [OperationContract]
        string Echo(string statement);

        [OperationContract]
        string GetWindowsIdentity();
        //[OperationContract]
        //System.Net.ICredentials GetDefaultCredentials();
        [OperationContract]
        string GetDefaultNetworkCredentials();
        [OperationContract]
        string GetHttpContextCurrentUser();
    }
}
