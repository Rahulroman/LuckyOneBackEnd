using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuckyOne.Entity
{
    public class Contest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContestId { get; set; }
        public string ContestName { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal EntryPoints { get; set; }
        public int TotalWinners { get; set; }
        public int MaxUsers { get; set; }
        public DateTime ContestDate { get; set; }
        public DateTime ResultDeclareTime { get; set; }
        public string Status { get; set; } = "OPEN";
    }
}
