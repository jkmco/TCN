using System.ComponentModel.DataAnnotations;

namespace TCN.Controllers.Resources
{
    public class TransactionResource
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TransactionCoinId { get; set; }
        [Required]
        public int TransactionFxId { get; set; }
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