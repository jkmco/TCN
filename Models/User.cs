using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TCN.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public ICollection<Transaction> Transactions { get; set; }   
        public User()
        {
            Transactions = new Collection<Transaction>();
        }
    }
}