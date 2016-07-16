using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DateTime Data { get; set; }

        public virtual ICollection<NewsComment> Comments { get; set; }

        public User User { get; set; }

    }
}
