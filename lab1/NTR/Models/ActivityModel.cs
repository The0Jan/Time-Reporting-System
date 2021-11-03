using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace NTR.Models {
    public class ActivityModel 
    {

        public ActivityModel() 
        {

            this.project_list = Entities.Project_List.load();
        }
        
        public Entities.Project_List project_list;
    }
}