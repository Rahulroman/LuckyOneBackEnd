using System;

namespace LuckyOne.DTOs.Contests
{
    public class ContestListItemDto
    {
        public int ContestId { get; set; }
        public string ContestName { get; set; } = "";
        public decimal EntryPoints { get; set; }
        public int MaxUsers { get; set; }
        //public int JoinedUsers { get; set; }
        public DateTime ContestDate { get; set; }
        public string Status { get; set; } = "";
    }
}
