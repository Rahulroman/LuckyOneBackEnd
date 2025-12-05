using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyOne.Entity
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Username { get; set; } 

        [MaxLength(200)]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public string?  Mobile { get; set; } 

        public bool? IsAdmin { get; set; }

        public DateTime? CreatedAt { get; set; } 

        public Boolean? IsActive { get; set; }

    }
}
