using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TCN.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TradeCoinId { get; set; }
        public int TradeFxId { get; set; }
        public int Price { get; set; }
        public int MinLimit { get; set; }
        public int MaxLimit { get; set; }  
        public ICollection<Photo> Photos { get; set; }
        
        public User User { get; set; }
        public TradeCoin Coin { get; set; }
        public TradeFx Fx { get; set; }

        public Trade()
        {
            Photos = new Collection<Photo>();
        }
    }
}