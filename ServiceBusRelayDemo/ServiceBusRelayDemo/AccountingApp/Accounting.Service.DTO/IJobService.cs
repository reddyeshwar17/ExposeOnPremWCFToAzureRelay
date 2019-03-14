using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Service.Contracts
{
    [ServiceContract(CallbackContract =typeof(IJobProgress))]
    public interface IJobService
    {

        [OperationContract(IsOneWay =true)]
        void JobRun(int jobId);
       
    }
}
