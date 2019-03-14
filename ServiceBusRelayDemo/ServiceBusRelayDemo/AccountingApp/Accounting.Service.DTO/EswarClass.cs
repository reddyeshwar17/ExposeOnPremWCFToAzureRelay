using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Service.Contracts
{
    // this is by eswar 
    class EswarClass : IJobProgress, IJobService, IAccountService
    {
        void IJobProgress.Completed(int jobNo)
        {
            throw new NotImplementedException();
        }

        AccountBalanceReponse IAccountService.GetAccountBalance(long accountNumber)
        {
            throw new NotImplementedException();
        }

        void IJobService.JobRun(int jobId)
        {
            throw new NotImplementedException();
        }

        void IJobProgress.Progress(int jobNo, string progress)
        {
            throw new NotImplementedException();
        }

        void IAccountService.UpdateAccountBalance(long accountNumber, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
