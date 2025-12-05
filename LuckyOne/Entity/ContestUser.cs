using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuckyOne.Entity
{
    public class ContestUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContestUserId { get; set; }
        public int ContestId { get; set; }
        public int UserId { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
        public int? Rank { get; set; }
        public bool IsWinner { get; set; }
        public decimal PrizePoints { get; set; }
    }
}
