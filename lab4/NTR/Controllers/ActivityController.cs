using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using NTR.Models;
using NTR.Data;
using NTR.Models.RestModels;
using AutoMapper;
namespace NTR.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private  DataContext _context;
    private  IMapper _mapper;

    public ActivityController(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{date}")]
    public IActionResult getActivities(DateTime date)
    {
       /// DateTime current_date = DateTime(date);
        int UserID = Convert.ToInt32(Request.Cookies["id"]);
        var activities = _context.Activities.Where(m => m.UserId == UserID 
                && m.Date == date);

        return Ok(activities);
    }

    [HttpPost("create")]
    public IActionResult Create( [FromBody] AcceptedActivity activity)
    {
        var new_activity = _mapper.Map<NTR.Models.Activity>(activity);
        new_activity.UserId = Convert.ToInt32(Request.Cookies["id"]);


        var partaking = _context.ProjectPartakes.Where(m => m.ProjectCode == new_activity.ProjectCode && m.UserId == new_activity.UserId
        && m.Month == new_activity.Date.Month && m.Year == new_activity.Date.Year).FirstOrDefault();
        if(partaking == null)
        {
            ProjectPartake partakings = new ProjectPartake();
            partakings.ProjectCode = new_activity.ProjectCode;
            partakings.UserId = new_activity.UserId;
            partakings.SubmittedTime = new_activity.Time;
            partakings.Year = new_activity.Date.Year;
            partakings.Month = new_activity.Date.Month;
            partakings.Submitted = false;
            _context.Add(partakings);
        }
        else
        {
            partaking.SubmittedTime += new_activity.Time;
            _context.Update(partaking);
        }

        _context.Activities.Add(new_activity);
        _context.SaveChanges();

        return Ok(activity);
    }

    [HttpPost("delete/{id}")]
    public IActionResult delete(int id)
    {
        var to_delete = _context.Activities.FirstOrDefault(m => m.ActivityId == id);

        var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.ProjectCode == to_delete.ProjectCode 
        && m.UserId == to_delete.UserId && m.Month == to_delete.Date.Month && m.Year == to_delete.Date.Year);
        partaking.SubmittedTime -= to_delete.Time;
        _context.ProjectPartakes.Update(partaking);



        _context.Activities.Remove(to_delete);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPost("update")]
    public IActionResult update( [FromBody] UpdatedActivity activity)
    {

        var to_update =_context.Activities.FirstOrDefault(m => m.ActivityId == activity.ActivityId);
        var partaking = _context.ProjectPartakes.FirstOrDefault(m => m.ProjectCode == to_update.ProjectCode 
        && m.UserId == to_update.UserId && m.Month == to_update.Date.Month && m.Year == to_update.Date.Year);

        int Time_dif = activity.Time - to_update.Time;
        to_update.Description = activity.Description;
        to_update.Time = Convert.ToInt32(activity.Time);
        to_update.SubcodeName = activity.SubcodeName;

        partaking.SubmittedTime += Time_dif;
        _context.SaveChanges();

        return Ok();
    }

    [HttpGet("activity/{id}")]
    public IActionResult getActivity(int id)
    {
        var activity = _context.Activities.FirstOrDefault(m => m.ActivityId == id);
        return Ok(activity);
    }

    [HttpGet("projects")]
    public IActionResult getProjects()
    {
       /// DateTime current_date = DateTime(date);
        var projects = _context.Projects.Where(m => m.Active == true );

        return Ok(projects);
    }
    [HttpGet("subcodes/{project}")]
    public IActionResult getSubcodes(string project)
    {
       /// DateTime current_date = DateTime(date);
        var subcodes = _context.Subcodes.Where(m => m.ProjectCode == project );

        return Ok(subcodes);
    }

    [HttpGet("partakings/{project}")]
    public IActionResult getPartakings(string project)
    {
        int UserID = Convert.ToInt32(Request.Cookies["id"]);
        var partakings = _context.ProjectPartakes.Where(m => m.UserId == UserID && m.ProjectCode == project);

        return Ok(partakings);
    }
}
