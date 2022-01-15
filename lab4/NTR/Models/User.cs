using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace NTR.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserModelId { get; set; }

        public string First_Name { get; set; } = "";

        public ICollection<Project>? Projects { get; set; }
        public ICollection<ProjectPartake>? ProjectPartakes { get; set; }
        public ICollection<Activity>? Activities { get; set; }

    }
}