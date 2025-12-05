using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuckyOne.Entity
{
    public class ContestPrize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrizeId { get; set; }
        public int ContestId { get; set; }
        public int RankFrom { get; set; }
        public int RankTo { get; set; }
        public decimal PrizePoints { get; set; }
    }
}
