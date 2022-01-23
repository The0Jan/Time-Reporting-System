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
using NTR.Models;
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
        _context.Activities.Add(new_activity);
        _context.SaveChanges();

        return Ok(activity);
    }

    [HttpPost("delete/{id}")]
    public IActionResult delete(int id)
    {
        var to_delete = _context.Activities.FirstOrDefault(m => m.ActivityId == id);
        _context.Activities.Remove(to_delete);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet("activity/{id}")]
    public IActionResult getActivity(int id)
    {
        var activity = _context.Activities.FirstOrDefault(m => m.ActivityId == id);
        return Ok(activity);
    }

    [HttpPost("update")]
    public IActionResult update( [FromBody] UpdatedActivity activity)
    {

        var to_update =_context.Activities.FirstOrDefault(m => m.ActivityId == activity.ActivityId);
        to_update.Description = activity.Description;
        to_update.Time = Convert.ToInt32(activity.Time);
        to_update.SubcodeName = activity.SubcodeName;
        _context.SaveChanges();

        return Ok();
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
}
