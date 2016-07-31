using System;
using System.ComponentModel.DataAnnotations;

namespace BC.Domain.Core
{
    public class ProjectComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? ParentProjectCommentId { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }

        public DateTime Data { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }
    }
}
