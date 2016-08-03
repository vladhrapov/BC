using System;
using System.ComponentModel.DataAnnotations;

namespace BC.Domain.Core
{
   public class FeedBack
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength (400)]
        public string Message { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }
    }
}
