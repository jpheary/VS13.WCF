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

namespace VS13.Prototype {
    //
    public class ApplicationGateway {
        //Members
        public const string SQL_CONNID = "Application1";

        private const string USP_READ = "uspApplication1Read",TBL_ = "Application1Table";

        //Interface
        public ApplicationGateway() { }

        public DataSet ReadApplication1() {
            //
            DataSet result = null;
            try {
                result = new DataService().FillDataset(SQL_CONNID,USP_READ,TBL_,new object[] { });
            }
            catch (Exception ex) { throw new ApplicationException(ex.Message,ex); }
            return result;
        }
    }
}
