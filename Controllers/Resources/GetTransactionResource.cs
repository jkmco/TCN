namespace TCN.Controllers.Resources
{
    public class GetTransactionResource
    {
        public int Id { get; set; }
        public UserResource User { get; set; }
        public KeyValuePairResource Coin { get; set; }
        public KeyValuePairResource Fx { get; set; }
        public int Price { get; set; }
        public int MinLimit { get; set; }
        public int MaxLimit { get; set; }  
        
    }
}