using Accounting.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.WebUI.Channels
{
    public interface IAccountServiceChannel:IAccountService,IClientChannel
    {
    }
}
