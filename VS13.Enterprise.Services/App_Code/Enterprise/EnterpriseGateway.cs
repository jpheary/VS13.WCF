using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace VS13.Enterprise {
    //
    public class EnterpriseGateway {
        //Members
        public const string SQL_CONNID = "Enterprise";


        //Interface
        public EnterpriseGateway() { }
    }
}
