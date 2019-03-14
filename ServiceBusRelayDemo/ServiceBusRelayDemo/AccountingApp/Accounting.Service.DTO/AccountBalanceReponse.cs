using System;
using System.Runtime.Serialization;

namespace Accounting.Service.Contracts
{
    [Serializable]
    [DataContract]
    public class AccountBalanceReponse
    {
        [DataMember]
        public string ServiceId { get; set; }
        
        [DataMember]
        public Double AccountBalance { get; set; }
    }
}
