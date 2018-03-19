namespace TCN.Controllers.Resources
{
    public class LoadTradeResource
    {
        public int Id { get; set; }
        public KeyValuePairResource User { get; set; }
        public KeyValuePairResource Coin { get; set; }
        public KeyValuePairResource Fx { get; set; }
        public int Price { get; set; }
        public int MinLimit { get; set; }
        public int MaxLimit { get; set; }  
        
    }
}