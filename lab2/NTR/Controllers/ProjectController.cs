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

        public IActionResult List(){
            return View();
        }

        [HttpGet]
        public IActionResult List(int Year, int Month){
            int id = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
            IEnumerable<ProjectPartake> partakings = _context.ProjectPartakes.Where(m => m.UserModelId == id && m.Year == Year && m.Month == Month).ToList();
            List<string> project_names  = new List<string>();
            
            foreach(var partake in partakings){
                string name = _context.Projects.FirstOrDefault(m=> m.ProjectModelId == partake.ProjectModelId).Title;
                project_names.Add(name);
            }
            ViewBag.projects = project_names;


            return View(partakings);
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
