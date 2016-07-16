using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Domain.Core
{
    public class NewsComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid NewsId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? ParentNewsCommentId { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }

        public DateTime Data { get; set; }

        public News News { get; set; }

        public User User { get; set; }
    }
}
