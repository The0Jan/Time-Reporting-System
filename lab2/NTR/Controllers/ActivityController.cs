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
            return View();
        }

        [HttpPost]
        public IActionResult Create(DateTime date, string ProjectName, string Subcode, int Time, string Description)
        {

            if(ProjectName==null || Subcode == null)
            {
                return RedirectToAction("Create", "Activity", new {@date = date, @ProjectName = ProjectName, @Subcode=Subcode, @Time=Time, @Description=Description});
            }
            else
            {
                var project = _context.Projects.FirstOrDefault(m => m.Title == ProjectName.ToUpper());   
                ActivityModel activityModel = new ActivityModel();
                activityModel.UserModelId = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
                activityModel.ProjectModelId = project.ProjectModelId;
                activityModel.Date = date;
                activityModel.Time = Time;
                activityModel.Description = Description;
                activityModel.Frozen = false;


                var subcode = _context.Subcodes.Where(m => m.ProjectModelId == project.ProjectModelId).FirstOrDefault(m => m.name == Subcode.ToLower());
                activityModel.SubcodeModelId = subcode.SubcodeModelId;
                
                var partaking = _context.ProjectPartakes.Where(m => m.ProjectModelId == project.ProjectModelId && m.UserModelId == activityModel.UserModelId).FirstOrDefault();
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
            ViewBag.subcode = subcode.name;
            return View( activity);
        }


        public IActionResult Delete(int id){
            var activity = _context.Activities.FirstOrDefault(m => m.ActivityModelId == id);
            var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.ProjectModelId == activity.ProjectModelId && m.UserModelId == Convert.ToInt32(Request.Cookies["users_UserModelId"]));
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


            ViewBag.project = project.Title;
            ViewBag.subcode = subcode.name;
            return View( activity);
        }

        [HttpPost]
        public IActionResult Edit(int id, int Time, string Description){
            var activity = _context.Activities.FirstOrDefault(m => m.ActivityModelId == id);
            var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.ProjectModelId == activity.ProjectModelId && m.UserModelId == activity.UserModelId);
            int Time_dif = Time - activity.Time;

            activity.Time = Time;
            activity.Description = Description;

            partaking.SubmittedTime += Time_dif;

            _context.Update(partaking);
            _context.Update(activity);
            _context.SaveChanges();
            return RedirectToAction("List", "Activity", new {@date = activity.Date});
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