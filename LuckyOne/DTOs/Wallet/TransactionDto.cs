using System;

namespace LuckyOne.DTOs.Wallet
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public decimal Points { get; set; }
        public string TransactionType { get; set; } = "";
        public string Description { get; set; } = "";
        public int? ContestId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
