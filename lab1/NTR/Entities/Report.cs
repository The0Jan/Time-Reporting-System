using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NTR.Entities
{
    public class Entry
    {
        public String date {get; set;}
        public String code{get; set;}
        public String subcode{get; set;}
        public int time{get; set;}
        public String description{get; set;}
    }

    public class AcceptedEntry
    {
        public String code{get; set;}
        public int time{get; set;}
    }

    public class Report
    {
        public bool frozen {get; set;}
        public List<Entry> entries {get; set;}
        public List<AcceptedEntry> acceptedEntries {get; set;}

        public static Report load(String user, DateTime date)
        {
            var path = $"baza/{user}-{date.Year}-{date.Month}.json";
            if (!System.IO.File.Exists(path)) {
                return new Report();
            }
            var report_json = System.IO.File.ReadAllText(path);
            return System.Text.Json.JsonSerializer.Deserialize<Report>(report_json);
        }

        public static void save(Report report, String user, DateTime date)
        {
            var path = $"baza/{user}-{date.Year}-{date.Month}.json";
            var json_options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(report, json_options);
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }
}