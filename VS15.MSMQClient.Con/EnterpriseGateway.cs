using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VS15.Enterprise;

namespace VS15 {
    class EnterpriseGateway {
        //Members
        private static bool _state = false;
        private static string _address = "";

        //Interface
        static EnterpriseGateway() {
            //
            ExceptionServiceClient client = new ExceptionServiceClient();
            _state = true;
            _address = client.Endpoint.Address.Uri.AbsoluteUri;
        }
        private EnterpriseGateway() { }
        public static bool ServiceState { get { return _state; } }
        public static string ServiceAddress { get { return _address; } }
        public static void WriteLogEntry(string message, LogLevel level) {
            //
            ExceptionServiceClient client = new ExceptionServiceClient();
            try {
                TraceMessage m = new TraceMessage();
                m.Name = "VS15";
                m.Source = "VS15.MSMQClient.Con";
                m.User = Environment.UserName;
                m.Computer = Environment.MachineName;
                m.LogLevel = level;
                m.Message = message;
                client.WriteLogEntry(m);
                client.Close();
            }
            catch (TimeoutException te) { client.Abort(); throw new ApplicationException(te.Message); }
            catch (FaultException fe) { client.Abort(); throw new ApplicationException(fe.Message); }
            catch (CommunicationException ce) { client.Abort(); throw new ApplicationException(ce.Message); }
        }
    }
}
