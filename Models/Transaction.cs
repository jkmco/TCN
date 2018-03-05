using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TCN.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransactionCoinId { get; set; }
        public int TransactionFxId { get; set; }
        public int Price { get; set; }
        public int MinLimit { get; set; }
        public int MaxLimit { get; set; }  
        public ICollection<Photo> Photos { get; set; }
        
        public User User { get; set; }
        public TransactionCoin Coin { get; set; }
        public TransactionFx Fx { get; set; }

        public Transaction()
        {
            Photos = new Collection<Photo>();
        }
    }
}