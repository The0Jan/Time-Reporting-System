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
    private  readonly IMapper _mapper;

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
        Console.Write(UserID);
        var activities = _context.Activities.Where(m => m.UserId == UserID 
                && m.Date == date);

        return Ok(activities);
    }

    [HttpPost("create")]
    public IActionResult Create( [FromBody] AcceptedActivity activity)
    {
        var new_activity = _mapper.Map<NTR.Models.Activity>(activity);
        Console.Write(new_activity.ActivityId);
        Console.Write(new_activity.Date);
        Console.Write(new_activity.Time);
        Console.Write(new_activity.Description);
        Console.Write(new_activity.Frozen);
        Console.Write(new_activity.UserId);
        Console.Write(new_activity.ProjectCode);
        Console.Write(new_activity.SubcodeName);

        new_activity.UserId = Convert.ToInt32(Request.Cookies["id"]);
        _context.Activities.Add(new_activity);
        _context.SaveChanges();

        return Ok(activity);
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var to_delete = _context.Activities.FirstOrDefault(m => m.ActivityId == id);
        _context.Activities.Remove(to_delete);
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
