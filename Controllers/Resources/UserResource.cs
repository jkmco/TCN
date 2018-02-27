using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TCN.Controllers.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public ICollection<TransactionResource> Transactions { get; set; }   
        public UserResource()
        {
            Transactions = new Collection<TransactionResource>();
        }
    }
}