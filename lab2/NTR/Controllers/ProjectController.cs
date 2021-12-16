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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Title, int Budget)
        {
            int id = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
            ProjectModel new_partake = new ProjectModel();
            new_partake.Title = Title;
            new_partake.Budget = Budget;
            new_partake.UserModelId = id;
            new_partake.Active = true;

            _context.Add(new_partake);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult MyProjects(int Year, int Month, string ProjectTitle)
        {
            int id = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
            var myProject = _context.Projects.FirstOrDefault(m=> m.UserModelId == id && m.Title==ProjectTitle);
            
            if(TempData["error"] != null){
                ViewBag.error = TempData["error"].ToString();
            }
            if(myProject == null)
            {
                ViewBag.project = "Project " + ProjectTitle + " does not exist. Please try again.";
                ViewBag.budget = 0;
                return View();
            }
            else{
                ViewBag.project = ProjectTitle;
                ViewBag.budget = myProject.Budget;
                ViewBag.active = myProject.Active;
                ViewBag.id = myProject.ProjectModelId;
                IEnumerable<ProjectPartake> partakings = _context.ProjectPartakes.Where(m => m.ProjectModelId == myProject.ProjectModelId && m.Year == Year && m.Month == Month).ToList();
                List<string> project_names  = new List<string>();

                if(partakings == null)
                {
                    return View();
                }

                foreach(var partake in partakings){
                    var worker = _context.Users.FirstOrDefault(m=> m.UserModelId == partake.UserModelId);
                    string worker_name = worker.First_Name + " " + worker.Last_Name;
                    project_names.Add(worker_name);
                }
                ViewBag.workers = project_names;
                return View(partakings);

            }
        }

        public IActionResult Change(int AcceptedTime, int ProjectPartakeId, string ProjectTitle, DateTime Timestamp){
            var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.ProjectPartakeId == ProjectPartakeId);

            if(!DateTime.Equals(Timestamp, partaking.Timestamp))
            {
                TempData["error"] = "Unable to change accepted time. Somebody already changed that.";
                return  RedirectToAction("MyProjects", "Project", new {@Year = partaking.Year, @Month = partaking.Month, @ProjectTitle = ProjectTitle});
            }

            var project = _context.Projects.FirstOrDefault(m => m.ProjectModelId == partaking.ProjectModelId);

            if(!project.Active)
            {
                TempData["error"] = "Unable to change accepted time. Project was shut down.";
                return  RedirectToAction("MyProjects", "Project", new {@Year = partaking.Year, @Month = partaking.Month, @ProjectTitle = ProjectTitle});
            }
            int change = AcceptedTime - partaking.AcceptedTime;
            partaking.AcceptedTime += change;
            project.Budget = project.Budget - change;

            _context.Update(partaking);
            _context.Update(project);
            _context.SaveChanges();
            return  RedirectToAction("MyProjects", "Project", new {@Year = partaking.Year, @Month = partaking.Month, @ProjectTitle = ProjectTitle});
        }

        public IActionResult CloseProject(int ProjectId){
            var project = _context.Projects.FirstOrDefault(m=> m.ProjectModelId == ProjectId);
            project.Active = false;

            _context.Update(project);
            _context.SaveChanges();
            return RedirectToAction("MyProjects", "Project");
        }
    }
}
