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

namespace NTR.Controllers;

[ApiController]
[Route("[controller]")]
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
        Console.Write("dupa");
        var users = _context.Users.ToList();
        Console.Write("dupa");

        return Ok(users);
    }


    
}
