using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BC.Domain.Core
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Guid? ProjectId { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public User User { get; set; }

    }
}
