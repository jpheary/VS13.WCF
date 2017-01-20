using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VS15.Magazine;

namespace VS15 {
    class Program: IMagazineServiceCallback {
        static void Main(string[] args) {
            //Always create an instance context to associate the service with            
            InstanceContext context = new InstanceContext(null, new Program());
            MagazineServiceClient client = new MagazineServiceClient(context);

            //Create a unique callback address (if you want multiple subscribers to run on the same machine)
            //WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
            //string uri = binding.ClientBaseAddress.AbsoluteUri;
            //uri += Guid.NewGuid().ToString();           // make it unique - append a GUID         
            //binding.ClientBaseAddress = new Uri(uri);   //uri += 9;

            //NetTcpBinding binding = (NetTcpBinding)client.Endpoint.Binding;
            //string uri = binding.ClientCallbackAddress.AbsoluteUri;
            //uri += Guid.NewGuid().ToString();           // make it unique - append a GUID         
            //binding.ClientCallbackAddress = new Uri(uri);   //uri += 9;

            //Subcribe
            Console.WriteLine("subscribing...");
            client.Subscribe();
            Console.WriteLine();
            Console.WriteLine("Press ENTER to unsubscribe");
            Console.ReadLine();
            Console.WriteLine("unsubscribing...");
            client.Unsubscribe();
            client.Close();
        }

        //Implement IClientContract
        public void MessageReceived(string linkToNewIssue, string issueNumber, DateTime publishDate) {
            //
            Console.WriteLine("MessageReceived(item{0}, item{1}, item{2}", linkToNewIssue, issueNumber, publishDate);
        }
    }
}
