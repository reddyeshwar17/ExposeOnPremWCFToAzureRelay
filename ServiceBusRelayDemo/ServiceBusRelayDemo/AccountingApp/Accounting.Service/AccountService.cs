using System.Diagnostics;
using Accounting.Service.Contracts;
using System;
using Microsoft.ServiceBus;

namespace Accounting.Service
{

    public class AccountService : IAccountService
    {
        public AccountBalanceReponse GetAccountBalance(long accountNumber)
        {

            var processId = Process.GetCurrentProcess().Id.ToString();
            return new AccountBalanceReponse()
            {
                ServiceId = processId,
                AccountBalance = new Random().Next(10, 1000)
            };
        }


        public void UpdateAccountBalance(long accountNumber, double amount)
        {
            Debug.WriteLine(amount);
        }
    }
}
