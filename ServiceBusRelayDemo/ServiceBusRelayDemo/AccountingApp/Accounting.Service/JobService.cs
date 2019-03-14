using Accounting.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Service
{ 
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class JobService : IJobService
    {
        IJobProgress jobProgressCallBack;
        public void JobRun(int jobId)
        {
            jobProgressCallBack = OperationContext.Current.GetCallbackChannel<IJobProgress>();

            Action<int> executeJob = new Action<int>(execute);
            executeJob.BeginInvoke(jobId,asyncResult => executeJob.EndInvoke(asyncResult),null);
        }

        private void execute(int jobId)
        {
            jobProgressCallBack.Progress(jobId, "Processing");

            Thread.Sleep(new TimeSpan(0,0,30));

            jobProgressCallBack.Completed(jobId);
        }
    }
}
