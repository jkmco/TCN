using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TCN.Controllers.Resources
{
    public class UserResource : KeyValuePairResource
    {          
        public ICollection<SaveTradeResource> Trades { get; set; }   
        public UserResource()
        {
            Trades = new Collection<SaveTradeResource>();
        }
    }
}