using Accounting.Service.Contracts;
using System.ServiceModel;

namespace Accounting.Service.Contracts
{
   
    [ServiceContract]
    
    public interface IAccountService
    {
        [OperationContract]
        AccountBalanceReponse GetAccountBalance(long accountNumber);

        [OperationContract]
        void UpdateAccountBalance(long accountNumber,double amount);
    }
}
