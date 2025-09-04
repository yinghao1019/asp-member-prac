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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating employee");
            ModelState.AddModelError(string.Empty, "An error occurred while creating the employee.");
        }
        return View(employee);
    }

    public IActionResult Update(int id)
    {
        var employee = _context.Employees.FirstOrDefault(employee => employee.EmpId == id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Update(Employee employee)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating employee");
            ModelState.AddModelError(string.Empty, "An error occurred while creating the employee.");
        }
        return View(employee);
    }

    public IActionResult Delete(int id)
    {


        var employee = _context.Employees.FirstOrDefault(employee => employee.EmpId == id);
        _context.Employees.Remove(employee);
        _context.SaveChanges();

        return RedirectToAction("Index");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
