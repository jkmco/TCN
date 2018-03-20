namespace TCN.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int TradeId { get; set; }
        public Trade Trade { get; set; }
    }
}