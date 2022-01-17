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

namespace NTR.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private  DataContext _context;

    public ActivityController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("{date}")]
    public IActionResult getActivities(DateTime date)
    {
       /// DateTime current_date = DateTime(date);
        int UserID = Convert.ToInt32(Request.Cookies["id"]);
        var activities = _context.Activities.Where(m => m.UserId == UserID && m.Date == date);

        return Ok(activities);
    }

    [HttpPost("create")]
    public IActionResult Create(NTR.Models.Activity activity)
    {
        activity.UserId = Convert.ToInt32(Request.Cookies["id"]);
        _context.Activities.Add(activity);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var to_delete = _context.Activities.FirstOrDefault(m => m.ActivityId == id);
        _context.Activities.Remove(to_delete);
        _context.SaveChanges();
        return Ok();
    }
    
}
