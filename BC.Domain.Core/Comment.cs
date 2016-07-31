using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BC.Domain.Core
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ParaentItemId { get; set; }

        public CommandType CommandType { get; set; }

        public Guid? UserId { get; set; }

        public Guid? ParentCommentId { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}
