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
        public List<Subactivity> subactivities{get; set;}
    }

    public class Subactivity
    {
        public string code {get; set;}
    }

    public class Project_List
    {
        public List<Activity> activities {get; set;}

        public static Project_List load()
        {
            var path = $"baza/activity.json";
            var report_json = System.IO.File.ReadAllText(path);
            return System.Text.Json.JsonSerializer.Deserialize<Project_List>(report_json); 
        }

        public static void save(Project_List pr_list)
        {
            var path = $"baza/activity.json";
            var json_options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(pr_list, json_options);
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }
}