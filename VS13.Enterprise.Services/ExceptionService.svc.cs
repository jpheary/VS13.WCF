using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Configuration;
using System.Web.Security;

namespace VS13.Enterprise {
    //
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ExceptionService:IExceptionService {
        //Members

        //Interface
        public ExceptionService() { }

        public void WriteLogEntry(TraceMessage m) {
            //Write o to database log if event level is severe enough
            new AppService(EnterpriseGateway.SQL_CONNID).WriteLogEntry(m);
        }
    }
}
