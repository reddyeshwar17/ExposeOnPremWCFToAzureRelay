using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Tcp;

            ServiceHost accountService = new ServiceHost(typeof(AccountService));
            accountService.Open();
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            accountService.Close();

        }

        private static void hostJobService()
        {

            //ServiceHost jobService = new ServiceHost(typeof(JobService));
            //jobService.Open();
            //jobService.Close();
        }
    }
}
