using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BC.Domain.Core.Enums;

namespace BC.Domain.Core
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(32)]
        public string Name { get; set; }

        //assignment (Text on payment) Призначення
        [Required]
        public string Description { get; set; }

        //Long text about project
        [Required]
        public string Info { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalSum { get; set; }

        [Range(0, double.MaxValue)]
        public double CurrentSum { get; set; }

        [NotMapped]
        public double NeedSum { get { return TotalSum - CurrentSum; } }

        public string Location { get; set; }

        public string YouTubeLink { get; set; }
        
        [Required]
        public ProjectStatus ProjectStatus { get; set; }

        [Required]
        public ProjectMark ProjectMark { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<ProjectComment> Comments { get; set; }

        public virtual ICollection<News> Newses{ get; set; }

    }
}
