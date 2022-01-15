using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTR.Models
{
    public class ProjectPartake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectPartakeId {get; set;}
        public int SubmittedTime {get; set;}
        public int AcceptedTime{get; set;}
        public int Year {get; set;}
        public int Month {get; set;}
        [DefaultValue(false)]
        public bool Submitted {get; set;}

        public string ProjectCode { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(ProjectCode))]
        public Project? Project{get; set;}
        [ForeignKey(nameof(UserId))]
        public User? User{get; set;}
    }
}