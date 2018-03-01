using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TCN.Controllers.Resources
{
    public class UserResource : KeyValuePairResource
    {          
        public ICollection<SaveTransactionResource> Transactions { get; set; }   
        public UserResource()
        {
            Transactions = new Collection<SaveTransactionResource>();
        }
    }
}