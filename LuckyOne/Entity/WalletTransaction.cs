using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuckyOne.Entity
{
    public class WalletTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public decimal Points { get; set; }
        public string TransactionType { get; set; } 
        public string Description { get; set; } 
        public int? ContestId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
