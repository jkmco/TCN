namespace TCN.Controllers.Resources
{
    public class TransactionResource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransactionCoinId { get; set; }
        public int TransactionFxId { get; set; }
        public int Price { get; set; }
        public int MinLimit { get; set; }
        public int MaxLimit { get; set; }  
    }
}