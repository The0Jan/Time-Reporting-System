using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTR.Models
{
    public class ProjectModel
    {
        public string ProjectModelId { get; set; }
        public int UserModelId { get; set; }
        public string Title { get; set; }
        public bool active { get; set; }
    }
}