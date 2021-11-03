using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NTR.Entities
{
    public class Activity
    {
        public String code{get; set;}
        public String manager{get; set;}
        public String name{get; set;}
        public int budget{get; set;}
        public bool active{get; set;}
        public List<String> subactivities{get; set;}
    }
}