using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NTR.Models
{
    public class ProjectModel
    {
        public int ProjectModelId { get; set; }
        public int UserModelId { get; set; } 
        public string Title { get; set; }
        public bool Active { get; set; }
        public int Budget {get; set;}
        public ICollection<SubcodeModel> Subcodes {get; set;}

        [ConcurrencyCheck]
        [Timestamp]
        public DateTime Timestamp { get; set; }
        }
}