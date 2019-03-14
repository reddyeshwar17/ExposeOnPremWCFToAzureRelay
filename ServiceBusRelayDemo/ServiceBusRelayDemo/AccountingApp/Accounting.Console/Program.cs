using Accounting.Service.Contracts;
using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Tcp;
            var accServiceChannelFac = new ChannelFactory<IAccountServiceChannel>("AccountService");
            var accountBalance = 0d;
            var serviceId = "0";

            var taskList = new List<Task<AccountBalanceReponse>>();



            IAccountServiceChannel accChannel = null;
            try
            {
                accChannel = accServiceChannelFac.CreateChannel();
                #region  Request Response

                for (int i = 0; i < 100; i++)
                {
                    taskList.Add(Task.Run(() => accChannel.GetAccountBalance(100)));
                }
                
                foreach (Task<AccountBalanceReponse> task in taskList)
                {

                    System.Console.WriteLine("Balance {0}  from  service id : {1}", task.Result.AccountBalance, task.Result.ServiceId);
                }
                #endregion

                #region  Fire and forget

                //accChannel.UpdateAccountBalance(1000, 100);
                //System.Console.WriteLine("Fire and forget triggered");

                #endregion

            }
            finally
            {
                if (accChannel != null)
                {
                    accChannel.Dispose();
                }
            }

            #region  Bi-Directional

            //var context = new InstanceContext(new Callback());
            //var jobServiceChannel = new DuplexChannelFactory<IJobServiceChannel>(context,"JobService");
            //IJobServiceChannel jobChannel = null;
            //try
            //{
               
            //    jobChannel = jobServiceChannel.CreateChannel();
            //    jobChannel.JobRun(new Random().Next(9000));
            //}
            //finally
            //{
            //    //jobChannel.Close();
            //}
            #endregion
            System.Console.ReadLine();

        }


        [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
        class Callback : IJobProgress
        {
            public void Completed(int jobNo)
            {
                System.Console.WriteLine(jobNo + " completed ");
                System.Console.ReadLine();
            }

            public void Progress(int jobNo, string progress)
            {
                System.Console.WriteLine(progress);
            }
        }
    }
}
