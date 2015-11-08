using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VS13.Enterprise {
    [ServiceContract(Namespace = "http://VS13.Enterprise")]
    public interface IExceptionService {
        //
        [OperationContract(IsOneWay = true)]
        void WriteLogEntry(TraceMessage m);
    }

}
