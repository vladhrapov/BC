using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BC.Domain.Core.Enums;

namespace BC.Domain.Core
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
