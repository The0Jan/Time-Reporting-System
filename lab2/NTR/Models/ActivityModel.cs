using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTR.Models
{
    public class ActivityModel
    {
        public int ActivityModelId { get; set; }
        public int UserModelId { get; set; }
        public string ProjectModelId { get; set; }
        public string SubcodeModelId { get; set; }
        public DateTime?  Date {get; set;}
        public int Time { get; set; }
        public string Description { get; set; }
        public bool Frozen { get; set; }

        public ActivityModel()
        {
        }

    }
}