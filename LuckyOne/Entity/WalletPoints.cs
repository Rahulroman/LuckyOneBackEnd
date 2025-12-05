using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuckyOne.Entity
{
    public class WalletPoints
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPoints { get; set; } 
        public DateTime UpdatedDate { get; set; } 
    }
}
