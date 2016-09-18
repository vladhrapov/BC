using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BC.Domain.Core.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BC.Domain.Core
{
    public class User : IdentityUser
    {
        [Required]
        public override string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }


        //[Key]
        //public Guid Id { get; set; }

        //[Required]
        //public string Login { get; set; }
        
        //[Required,MinLength(8)]
        //public string Password { get; set; }

        //[Required]
        //public UserType UserType { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
