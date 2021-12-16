using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NTR.Models
{
    public class ProjectPartake
    {
        public int ProjectPartakeId {get; set;}
        public int ProjectModelId { get; set; }
        public int UserModelId { get; set; }
        public int SubmittedTime {get; set;}
        public int AcceptedTime{get; set;}
        public int Year {get; set;}
        public int Month {get; set;}
        public bool Submitted {get; set;}

        [ConcurrencyCheck]
        [Timestamp]
        public DateTime Timestamp { get; set; }
    }
}