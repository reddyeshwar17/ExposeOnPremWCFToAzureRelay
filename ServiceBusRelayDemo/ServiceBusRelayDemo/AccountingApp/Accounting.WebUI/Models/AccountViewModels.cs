using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Accounting.WebUI.Models
{
    public class AccountViewModel
    {

        public AccountViewModel()
        {
            AccountNumber = 1000;
        }

        [DisplayName("Account Number")]
        public long AccountNumber { get; set; }

        [DisplayName("Account Balance")]
        public double AccountBalance { get; set; }

        [DisplayName("Service Id")]
        public string ServiceId { get; internal set; }
    }
}

