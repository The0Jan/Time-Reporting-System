using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTR.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace NTR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(new SelectModel());
        }

        [HttpPost]
        public IActionResult Index(string users)
        {
            var options = new CookieOptions { HttpOnly = true, Secure = false, MaxAge = TimeSpan.FromMinutes(10) };
            Response.Cookies.Append("users", users, options);

            return RedirectToAction("Account", "Home");
        }

        [HttpGet]
        public IActionResult Account(DateTime? date)
        {

            ViewBag.Name = Request.Cookies["users"];

            if (date.HasValue) {
                return View(new ActivitiesForDayModel(Request.Cookies["users"],date.Value));
            } else {
                return View(new ActivitiesForDayModel(Request.Cookies["users"]));
            }
        }

        [HttpPost]
        public IActionResult Account(string date, int id)
        {
            DateTime date_formatted = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ActivitiesForDayModel Updated_activities = new ActivitiesForDayModel(Request.Cookies["users"],date_formatted);
            Updated_activities.Activities.entries.RemoveAt(id);
            Entities.Report.json_save(Updated_activities.Activities,Request.Cookies["users"],date_formatted );

            return View(new ActivitiesForDayModel(Request.Cookies["users"],date_formatted));
        }

        [HttpGet]
        public IActionResult Details(string date, int id)
        {
            DateTime date_formatted = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ViewBag.id = id;
            return View(new ActivitiesForDayModel(Request.Cookies["users"],date_formatted));
        }


        [HttpGet]
        public IActionResult Edit_info(string date, int id)
        {
            DateTime date_formatted = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            EditEntryModel edit = new EditEntryModel(new ActivitiesForDayModel(Request.Cookies["users"],date_formatted).Activities.entries[id], id);
            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit_info(EditEntryModel entry)
        {
            DateTime date_formatted = DateTime.ParseExact(entry.date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ActivitiesForDayModel activity = new ActivitiesForDayModel(Request.Cookies["users"],date_formatted);
            activity.Activities.entries[entry.id].subcode = entry.subcode;
            activity.Activities.entries[entry.id].description = entry.description;
            activity.Activities.entries[entry.id].time = entry.time;

            Entities.Report.json_save(activity.Activities,Request.Cookies["users"],date_formatted );

            return RedirectToAction("Account", "Home", new {@date = date_formatted});
        }


        [HttpGet]
        public IActionResult Create(string date)
        {
            ViewBag.date = date;
            return View(new ActivityModel());
        }

        [HttpPost]
        public IActionResult Create(EditEntryModel entry)
        {
            DateTime date_formatted = DateTime.ParseExact(entry.date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ActivitiesForDayModel activity = new ActivitiesForDayModel(Request.Cookies["users"],date_formatted);
            NTR.Entities.Entry new_entry = new NTR.Entities.Entry();
            new_entry.date = entry.date;
            new_entry.code = entry.code;
            new_entry.subcode = entry.subcode;
            new_entry.time = entry.time;
            new_entry.description = entry.description;

            activity.Activities.entries.Add(new_entry);
            Entities.Report.json_save(activity.Activities,Request.Cookies["users"],date_formatted );

            return RedirectToAction("Account", "Home", new {@date = date_formatted});
        }

        [HttpGet]
        public IActionResult MonthlyCheck(string date)
        {
            ViewBag.date = date;
            return View(new MonthlyCheckModel(Request.Cookies["users"],date));
        }
        [HttpGet]
        public IActionResult CreateProject()
        {
            ViewBag.name = Request.Cookies["users"];
            return View(new ActivityModel());
        }





        [HttpGet]
        public IActionResult ProjectManagment(DateTime? date, string project, string member)
        {

            ViewBag.name = Request.Cookies["users"];
            
            if (!date.HasValue || project == null)
            {
                ViewBag.date = "Not Yet selected";
                return View(new ProjectManagmentModel(Request.Cookies["users"]));
            }
            else
            {
                ViewBag.show_date = date.Value.ToString("yyyy-MM", CultureInfo.InvariantCulture);
                ViewBag.return_date = date.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                return View(new ProjectManagmentModel(Request.Cookies["users"], project, date.Value, member));   
            }

        }

        [HttpPost]
        public IActionResult CloseProject(DateTime date, string project, string member)
        {
            Entities.Project_List updated_list =  Entities.Project_List.load();
            for(int i=0; i<updated_list.activities.Count; i++)
            {
                if(Equals(updated_list.activities[i].code, project))
                {
                    updated_list.activities[i].active = false;
                    break;
                }
            }
            Entities.Project_List.save(updated_list);

            return RedirectToAction("ProjectManagment", "Home", new {@date = date, @project = project, @member = member});
        }
        
        [HttpPost]
        public IActionResult ProjectManagment(int accepted_time, string member, DateTime month, string project, int previous_accepted_time, int budget)
        {
            Entities.Report new_report = Entities.Report.json_load(member, month);
            for(int i=0; i<new_report.accepted.Count; i++)
            {
                if(Equals(new_report.accepted[i].code, project))
                {
                    new_report.accepted[i].time = accepted_time;
                    break;
                }
            }

            if(0 == new_report.accepted.Count )
            {
                Entities.AcceptedEntry new_entry = new Entities.AcceptedEntry();
                new_entry.time = accepted_time;
                new_entry.code = project;
                new_report.accepted = new List<Entities.AcceptedEntry>();
                new_report.accepted.Add(new_entry);
            }
            Entities.Report.json_save(new_report,member, month);

            int correct = accepted_time - previous_accepted_time ;
            Entities.Project_List updated_list =  Entities.Project_List.load();
            for(int i=0; i<updated_list.activities.Count; i++)
            {
                if(Equals(updated_list.activities[i].code, project))
                {
                    updated_list.activities[i].budget = budget - correct;
                    break;
                }
            }
            Entities.Project_List.save(updated_list);
            return RedirectToAction("ProjectManagment", "Home", new {@date = month, @project = project, @member = member});
        }

        [HttpPost]
        public IActionResult CreateProject(Entities.Activity project)
        {
            ActivityModel updated_projects = new ActivityModel();
            project.active = true;
            updated_projects.project_list.activities.Add(project);
            Entities.Project_List.save(updated_projects.project_list);
            return RedirectToAction("Account", "Home");
        }

        [HttpPost]
        public IActionResult FreezeMonth(string date)
        {
            DateTime date_formatted = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ActivitiesForDayModel activity = new ActivitiesForDayModel(Request.Cookies["users"],date_formatted); 
            activity.Activities.frozen = true;

            Entities.Report.json_save(activity.Activities,Request.Cookies["users"],date_formatted );

            return RedirectToAction("Account", "Home", new {@date = date_formatted});

        }

        public IActionResult LogOut()
        {
            if (Request.Cookies["users"] != null)
            {
                Response.Cookies.Delete("users");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
