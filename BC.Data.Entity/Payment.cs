using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Data.Entity
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
