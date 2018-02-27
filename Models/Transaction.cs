namespace TCN.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransactionCoinId { get; set; }
        public int TransactionFxId { get; set; }
        public int Price { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public User User { get; set; }
        public TransactionCoin Coin { get; set; }
        public TransactionFx Fx { get; set; }
    }
}