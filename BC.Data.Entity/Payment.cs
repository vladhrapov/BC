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
        public int Id { get; set; }
        [Required]
        public int CheckNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int Sum { get; set; }
        [Required]
        public string Info { get; set; }
        public int QR { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public int? UserId { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
