using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Service.Contracts
{
   
    public interface IJobProgress
    {
        [OperationContract(IsOneWay = true)]
        void Progress(int jobNo, string progress);

        [OperationContract(IsOneWay = true)]
        void Completed(int jobNo);

    }
}
