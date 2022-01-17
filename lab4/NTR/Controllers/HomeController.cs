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
public class HomeController : ControllerBase
{

    private  DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpPost("{id}/login")]
    public IActionResult Login(int id)
    {
        var user = _context.Users.FirstOrDefault(m => m.UserId == id);
        if(user == null)
            return NotFound(); /// Co to kurwa jest niby
        var options = new CookieOptions { HttpOnly = false, Secure = true, MaxAge = TimeSpan.FromMinutes(60) };
        Response.Cookies.Append("user", user.First_Name, options);
        Response.Cookies.Append("id", user.UserId.ToString(), options);

        return Ok();
    }
    
    [HttpPost("logout")]
    public IActionResult LogOut()
    {

        var options = new CookieOptions { HttpOnly = false, Secure = true, Expires = DateTime.Now.AddDays(-1) };
        Response.Cookies.Delete("user", options);
        Response.Cookies.Delete("id", options);
        
        return Ok();
    }

    [HttpPost("logged")]
    public IActionResult LoggedIn()
    {
        int cur_id = Convert.ToInt32(Request.Cookies["id"]);
        var current = _context.Users.FirstOrDefault(m => m.UserId == cur_id);
        return Ok(current);
    }
    
}
