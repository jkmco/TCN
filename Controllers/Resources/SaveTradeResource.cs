using System.ComponentModel.DataAnnotations;

namespace TCN.Controllers.Resources
{
    public class SaveTradeResource
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TradeCoinId { get; set; }
        [Required]
        public int TradeFxId { get; set; }
        [Required]
        [Range(0,10000000)]
        public int Price { get; set; }
        [Required]
        [Range(0,10000000)]
        public int MinLimit { get; set; }
        [Required]
        [Range(0,10000000)]        
        public int MaxLimit { get; set; }  
    }
}