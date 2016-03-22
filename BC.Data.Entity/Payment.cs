using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Data.Entity
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
    }
}
