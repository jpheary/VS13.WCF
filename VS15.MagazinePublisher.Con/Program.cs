using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VS15.Magazine;

namespace VS15 { 
    class Program:IMagazineServiceCallback {
        static void Main(string[] args) {
            //
            MagazineServiceClient client = null;
            try {
                // always create an instance context to associate the service with            
                InstanceContext context = new InstanceContext(null, new Program());
                client = new MagazineServiceClient(context);
                Console.WriteLine("Publishing New Issue(http://www.jpheary.com, Vol1: Number1, )");
                client.PublishMagazine("http://www.jpheary.com", "Vol1: Issue1", System.DateTime.Now);
                Console.WriteLine();
                Console.WriteLine("Press ENTER to stop publishing events");
                Console.ReadLine();

                //Closing the client gracefully closes the connection and cleans up resources
                client.Close();
            }
            catch (TimeoutException te) { client.Abort(); throw new ApplicationException(te.Message); }
            catch (FaultException<MagazineFault> efe) {
                client.Abort();
                Console.Write(efe.Detail.Message);
            }
            catch (FaultException fe) { client.Abort(); throw new ApplicationException(fe.Message); }
            catch (CommunicationException ce) { client.Abort(); throw new ApplicationException(ce.Message); }
        }

        //Implement IClientContract
        public void MessageReceived(string linkToNewIssue, string issueNumber, DateTime publishDate) {
            Console.WriteLine("MessageReceived(item{0}, item{1}, item{2}", linkToNewIssue, issueNumber, publishDate);
        }
    }
}