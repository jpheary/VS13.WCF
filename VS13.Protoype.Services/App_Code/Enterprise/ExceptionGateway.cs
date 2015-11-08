using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.Threading;

namespace VS13.Enterprise {
	//
	public class ExceptionGateway {
		//Members
        
		//Interface
        public ExceptionGateway() {  }
        public CommunicationState ServiceState { get { return new ExceptionServiceClient().State; } }
        public string ServiceAddress { get { return new ExceptionServiceClient().Endpoint.Address.Uri.AbsoluteUri; } }

        public void WriteLogEntry(TraceMessage message) {
            //Get the operating enterprise terminal
            ExceptionServiceClient client = new ExceptionServiceClient();
            try {
                client.WriteLogEntry(message);
                client.Close();
            }
            catch (TimeoutException te) { client.Abort(); throw new ApplicationException(te.Message); }
            catch (FaultException fe) { client.Abort(); throw new ApplicationException(fe.Message); }
            catch (CommunicationException ce) { client.Abort(); throw new ApplicationException(ce.Message); }
        }
    }
}