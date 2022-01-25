using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace NTR.Models
{
    public class Subcode
    {
        [Key]
        public string Name { get; set; } = "";
        public string ProjectCode { get; set; } = "";

        [ForeignKey(nameof(ProjectCode))]
        public Project? Projects { get; set; }

    }
}