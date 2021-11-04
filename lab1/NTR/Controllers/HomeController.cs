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
