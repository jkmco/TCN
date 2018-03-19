namespace TCN.Controllers.Resources
{
    public class TradeQueryResource
    {
        public int? TradeId { get; set; }
        public int? CoinId { get; set; }
        public int? FxId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}