using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp_member_prac.Models;
using asp_member_prac.Data;

namespace asp_member_prac.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EmployeeDbContext _context;

    public HomeController(ILogger<HomeController> logger, EmployeeDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {

        var employees = _context.Employees.ToList();
        return View(employees);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
