using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CourseAdvisoryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
namespace CourseAdvisoryApplication.Controllers
{
    public class DegreeController : Controller
    {
    private readonly ILogger<DegreeController> _logger;
    private readonly MyDbContext _context;
    public DegreeController(ILogger<DegreeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Degree()
    {
        //var degreeList = _context.Degree.ToList();
        List<Degree> degreeList = new List<Degree>();
        degreeList = _context.Degree.ToList();
        var selectListItems = degreeList.Select(d => new SelectListItem
        {
        Value = d.DegreeId.ToString(), // Assuming Id is the property representing the value
        Text = d.DegreeName // Assuming DegreeName is the property representing the text
        });
        // Pass data to the view
        ViewBag.DropDownValues = new SelectList(selectListItems, "Value", "Text"); 
        //ViewBag.DegreeList = new SelectList(degreeList, "DegreeId", "DegreeName");
        //return View();
        if(ViewBag.DropDownValues != null)
        {
        return View(ViewBag);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Degree(string selectedValue)
    {  
        if(selectedValue is not null)
        {    
            //&& selectedValue.Equals("Master of Science in Computer Science")
            TempData["Degree"] = selectedValue;
            return RedirectToAction("SelectCourses", "Graduate");
        }
        else
        {
            TempData["Message"] = "Please select a Degree value";
            return RedirectToAction("Submit", "Degree");
        }
    }  
  }
}