using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using NTR.Models;
using NTR.Data;

namespace NTR.Controllers
{
    public class HomeController : Controller
    {
        private  DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var users = _context.Users.FirstOrDefault(m => m.UserModelId == id);

            var options = new CookieOptions { HttpOnly = true, Secure = false, MaxAge = TimeSpan.FromMinutes(10) };
            Response.Cookies.Append("users_FirstName", users.Last_Name, options);
            Response.Cookies.Append("users_LastName", users.First_Name, options);
            string ID = users.UserModelId.ToString();

            Response.Cookies.Append("users_UserModelId", ID, options);

            return RedirectToAction("List", "Activity");
        }

      public IActionResult LogOut()

        {
            if (Request.Cookies["Users_FirstName"] != null)
            {
                Response.Cookies.Delete("users_FirstName");
                Response.Cookies.Delete("users_LastName");
                Response.Cookies.Delete("users_UserModelId");
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
