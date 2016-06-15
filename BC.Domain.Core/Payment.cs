using System;
using System.ComponentModel.DataAnnotations;

namespace BC.Domain.Core
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int CheckNumber { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        public string Info { get; set; }

        public string QR { get; set; }

        [Required]
        public bool IsDemonstration { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public Guid? UserId { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}
