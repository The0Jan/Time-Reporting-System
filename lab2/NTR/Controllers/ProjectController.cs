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
    public class ProjectController : Controller
    {
        private  DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List(int Year, int Month){

            return View();
        }


        [HttpPost]
        public IActionResult Create(string Title, int Budget)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowOff()
        {
            return View();
        }
    }
}
