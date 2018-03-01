using TCN.Extensions;

namespace TCN.Models
{
    public class TransactionQuery : IQueryObject
    {
        public int? TransactionId { get; set; }
        public int? CoinId { get; set; }
        public int? FxId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}