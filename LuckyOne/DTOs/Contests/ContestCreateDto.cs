using System;

namespace LuckyOne.DTOs.Contests
{
    public class ContestCreateDto
    {
        public string ContestName { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal EntryPoints { get; set; }
        public int TotalWinners { get; set; }
        public int MaxUsers { get; set; }
        public DateTime ContestDate { get; set; }
        public DateTime ResultDeclareTime { get; set; }
    }
}
