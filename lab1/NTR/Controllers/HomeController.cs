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
            DateTime result = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ActivitiesForDayModel Updated_activities = new ActivitiesForDayModel(Request.Cookies["users"],result);
            Updated_activities.Activities.entries.RemoveAt(id);
            Entities.Report.save(Updated_activities.Activities,Request.Cookies["users"],result );

            return View(new ActivitiesForDayModel(Request.Cookies["users"],result));
        }

        [HttpGet]
        public IActionResult Details(string date, int id)
        {
            DateTime result = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ViewBag.id = id;
            return View(new ActivitiesForDayModel(Request.Cookies["users"],result));
        }


        [HttpGet]
        public IActionResult Edit(string date, int id)
        {
            DateTime result = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ViewBag.id = id;
            return View(new ActivitiesForDayModel(Request.Cookies["users"],result));
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
