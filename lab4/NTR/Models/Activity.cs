using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTR.Models
{
    public class Activity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }
        public DateTime  Date {get; set;}
        public int Time { get; set; }
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool Frozen { get; set; }

        public int UserId { get; set; } 
        public string ProjectCode { get; set; } = "";
        public string? SubcodeName { get; set; } = "";

        [ForeignKey(nameof(UserId))]
        public User? User {get; set;}
        [ForeignKey(nameof(ProjectCode))]
        public Project? Project {get; set;}
        [ForeignKey(nameof(ProjectCode))]
        public Subcode? Subcode {get; set;}

    }
}