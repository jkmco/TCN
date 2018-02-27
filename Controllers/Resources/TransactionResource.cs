namespace TCN.Controllers.Resources
{
    public class TransactionResource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransactionCoinId { get; set; }
        public int TransactionFxId { get; set; }
        public AmountResource Amount { get; set; }
    }

    public class AmountResource
    {
        public int Price { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }  
    }
}