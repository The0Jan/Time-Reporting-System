using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTR.Data;
using NTR.Models;

namespace NTR.Controllers
{
    public class ActivityController : Controller
    {
        private readonly DataContext _context;

        public ActivityController(DataContext context)
        {
            _context = context;
        }

       [HttpGet]

        public IActionResult List(DateTime? date)
        {
            DateTime new_date;
            int id = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
            if (date != null) {
                new_date = (DateTime) date;
            } 
            else {
                new_date = DateTime.Today;
            }
            if(TempData["error"] != null){
                ViewBag.error = TempData["error"].ToString();
            }
            ViewBag.date = new_date;
            ViewBag.submitted = 0;
            var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.UserModelId == id && m.Year == new_date.Year && m.Month == new_date.Month);
            if ( partaking != null && partaking.Submitted == true){
                ViewBag.submitted = 1;
            }
            return View( _context.Activities.Where(m => m.UserModelId == id && m.Date == new_date));

        }

        public IActionResult Create(DateTime? date, string? ProjectName, string? Subcode, int? Time, String? Description )
        {
            ViewBag.date = date;
            ViewBag.project = ProjectName;
            ViewBag.subcode = Subcode;
            ViewBag.times = Time;
            ViewBag.description = Description;
            if(TempData["error"] != null){
                ViewBag.error = TempData["error"].ToString();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(DateTime date, string ProjectName, string? Subcode, int Time, string? Description)
        {
            var project = _context.Projects.FirstOrDefault(m => m.Title == ProjectName.ToUpper());   
            if(project==null )
            {
                TempData["error"] = "There is no such project as " + ProjectName  ;
                return RedirectToAction("Create", "Activity", new {@date = date, @ProjectName = ProjectName, @Subcode=Subcode, @Time=Time, @Description=Description});
            }
            else if(project.Active == false){
                TempData["error"] = "There is no active project with name  " + ProjectName  ;
                return RedirectToAction("Create", "Activity", new {@date = date, @ProjectName = ProjectName, @Subcode=Subcode, @Time=Time, @Description=Description});
            }
            else
            {
                ActivityModel activityModel = new ActivityModel();
                activityModel.UserModelId = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
                activityModel.ProjectModelId = project.ProjectModelId;
                activityModel.Date = date;
                activityModel.Time = Time;
                activityModel.Description = Description;
                activityModel.Frozen = false;

                if(Subcode == null){
                    activityModel.SubcodeModelId = null;
                }
                else{
                    var subcode = _context.Subcodes.Where(m => m.ProjectModelId == project.ProjectModelId).FirstOrDefault(m => m.name == Subcode.ToLower());
                    if(subcode != null){
                    activityModel.SubcodeModelId = subcode.SubcodeModelId;
                    }
                    else{
                        activityModel.SubcodeModelId = null;
                    }
                }
                var partaking = _context.ProjectPartakes.Where(m => m.ProjectModelId == project.ProjectModelId && m.UserModelId == activityModel.UserModelId
                && m.Month == date.Month && m.Year == date.Year).FirstOrDefault();
                if(partaking == null)
                {
                    ProjectPartake partakings = new ProjectPartake();
                    partakings.ProjectModelId = project.ProjectModelId;
                    partakings.UserModelId = activityModel.UserModelId;
                    partakings.SubmittedTime = Time;
                    partakings.Year = date.Year;
                    partakings.Month = date.Month;
                    partakings.Submitted = false;
                    _context.Add(partakings);
                }
                else
                {
                    partaking.SubmittedTime += Time;
                    _context.Update(partaking);
                }

                _context.Add(activityModel);
                _context.SaveChanges();
                return RedirectToAction("List", "Activity", new {@date = date});
            }
   
        }

        [HttpGet]
        public IActionResult Details(int id){
            var activity = _context.Activities.FirstOrDefault(m => m.ActivityModelId == id);
            var project = _context.Projects.FirstOrDefault(m => m.ProjectModelId == activity.ProjectModelId);
            var subcode = _context.Subcodes.FirstOrDefault(m => m.SubcodeModelId == activity.SubcodeModelId);

            ViewBag.project = project.Title;
            if(subcode != null){
                ViewBag.subcode = subcode.name;
            }
            return View( activity);
        }


        public IActionResult Delete(int id){
            var activity = _context.Activities.FirstOrDefault(m => m.ActivityModelId == id);

            if (activity == null)
            {
                TempData["error"] = "Unable to save changes. Somebody already deleted that activity.";
                return RedirectToAction("List", "Activity");
            }

            var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.ProjectModelId == activity.ProjectModelId 
            && m.UserModelId == activity.UserModelId && m.Month == activity.Date.Month && m.Year == activity.Date.Year);
            if (partaking.Submitted == true){
                TempData["error"] = "Delete Entry. Somebody already submitted this month.";
                return RedirectToAction("List", "Activity",  new {@date = activity.Date});
            }
            partaking.SubmittedTime -= activity.Time;


            _context.ProjectPartakes.Update(partaking);
            _context.Activities.Remove(activity);
            _context.SaveChanges();

            return RedirectToAction("List", "Activity", new {@date = activity.Date});
        }

        [HttpGet]
        public IActionResult Edit(int id){
            var activity = _context.Activities.FirstOrDefault(m => m.ActivityModelId == id);
            var project = _context.Projects.FirstOrDefault(m => m.ProjectModelId == activity.ProjectModelId);
            var subcode = _context.Subcodes.FirstOrDefault(m => m.SubcodeModelId == activity.SubcodeModelId);

            if(TempData["error"] != null){
                ViewBag.error = TempData["error"].ToString();
            }

            ViewBag.project = project.Title;
            if(subcode != null){
                ViewBag.subcode = subcode.name;
            }
            return View( activity);
        }

        [HttpPost]
        public IActionResult Edit(int id, int Time, string Description, DateTime Timestamp){
            var activity = _context.Activities.FirstOrDefault(m => m.ActivityModelId == id);

            if (activity == null)
            {
                TempData["error"] = "Unable to save changes. Somebody already deleted that activity.";
                return RedirectToAction("List", "Activity");
            }

            var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.ProjectModelId == activity.ProjectModelId 
            && m.UserModelId == activity.UserModelId && m.Month == activity.Date.Month && m.Year == activity.Date.Year);

            if (partaking.Submitted == true){
                TempData["error"] = "Unable to save changes. Somebody already submitted this month.";
                return RedirectToAction("List", "Activity",  new {@date = activity.Date});
            }

            int Time_dif = Time - activity.Time;
            activity.Time = Time;
            activity.Description = Description;
            partaking.SubmittedTime += Time_dif;

            if(DateTime.Equals(activity.Timestamp, Timestamp)){
                _context.Update(partaking);
                _context.Update(activity);
                _context.SaveChanges();
                return RedirectToAction("List", "Activity", new {@date = activity.Date});

            }
            else{
                TempData["error"] = "Somebody already changed this activity.";
                return RedirectToAction("Edit", "Activity", new {@id = id});
            }

        }


        public IActionResult Submit(DateTime date){
            int id = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
            IEnumerable<ProjectPartake> partaking = _context.ProjectPartakes.Where(m => m.UserModelId == id && m.Year == date.Year && m.Month == date.Month);
            foreach(var item in partaking){
                item.Submitted = true;
                _context.Update(item);
            }
            _context.SaveChanges();

            return RedirectToAction("List", "Activity", new {@date = date});
        }

    }
}