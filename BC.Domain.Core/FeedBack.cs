using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Name { get; set; }
    }
}
