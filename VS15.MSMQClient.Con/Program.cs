using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS15.Enterprise;

namespace VS15 {
    class Program {
        static void Main(string[] args) {
            EnterpriseGateway.WriteLogEntry("Testing the Enterprise exception logging service.", LogLevel.Error);
        }
    }
}
