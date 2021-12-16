using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTR.Models
{
    public class ActivityModel
    {
        public int ActivityModelId { get; set; }
        public int UserModelId { get; set; } 
        public int ProjectModelId { get; set; }
        public int SubcodeModelId { get; set; }
        public DateTime?  Date {get; set;}
        public int Time { get; set; }
        public string Description { get; set; }
        public bool Frozen { get; set; }

        [Timestamp]
        public DateTime Timestamp { get; set; }
        public ActivityModel()
        {
        }

    }
}