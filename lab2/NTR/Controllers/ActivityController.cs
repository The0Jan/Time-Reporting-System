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
            int id = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
            if (date.HasValue) {
                ViewBag.date = date;
                return View( _context.Activities.Where(m => m.UserModelId == id && m.Date == date));
            } 
            else {
                DateTime today = DateTime.Today;
                ViewBag.date = today;
                return View( _context.Activities.Where(m => m.UserModelId == id && m.Date == today));
            }
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
            ActivityModel activityModel = new ActivityModel();
            var project = _context.Projects.FirstOrDefault(m => m.Title == ProjectName.ToUpper());
            var subcode = _context.Subcodes.Where(m => m.ProjectModelId == project.ProjectModelId).FirstOrDefault(m => m.name == Subcode.ToLower());
   

            if(project==null || subcode==null){
                return RedirectToAction("Create", "Activity", new {@date = date, @ProjectName = ProjectName, @Subcode=Subcode, @Time=Time, @Description=Description});
            }
            else{
                activityModel.UserModelId = Convert.ToInt32(Request.Cookies["users_UserModelId"]);
                activityModel.ProjectModelId = project.ProjectModelId;
                activityModel.SubcodeModelId = subcode.SubcodeModelId;
                activityModel.Date = date;
                activityModel.Time = Time;
                activityModel.Description = Description;
                activityModel.Frozen = false;

                _context.Add(activityModel);
                _context.SaveChanges();
                return RedirectToAction("List", "Activity", new {@date = date});
            }
   
        }

    }
}