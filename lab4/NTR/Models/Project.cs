using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTR.Models
{
    public class Project
    {
        [Key]
        public string ProjectCode { get; set; } = "";
        public int UserId { get; set; } 
        public string Title { get; set; } = "";
        [DefaultValue(true)]
        public bool Active { get; set; }
        public int Budget {get; set;}

        [ForeignKey(nameof(UserId))]
        public User? User {get; set;}
        public ICollection<Activity> Activities {get; set;}
        public ICollection<Subcode> Subcodes {get; set;}

        }
}