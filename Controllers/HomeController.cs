using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseAdvisoryApplication.Models;
using Microsoft.AspNetCore.Http;

namespace CourseAdvisoryApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyDbContext _context;

    // Combine both dependencies into a single constructor
    public HomeController(ILogger<HomeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

     public IActionResult Signup(string username, string password, string confirmpassword, string advisorname)
        {
            if (username is null || password is null || confirmpassword is null )
            {
               TempData["Message"] = "Please enter all the values.";
                return View();
            }
            else
            {
                if (password == confirmpassword)
                {
                    var userdata = new Users
                    {
                        UserName = username,
                        Password = password,
                        AdvisorName = "Dr. Sudhir Trivedi"
                        
                    };
                    _context.Users.Add(userdata);
                    _context.SaveChanges();
                    return View("Login");
                }
                else
                {
                TempData["Message"] = "Password and confirm password are not matching, please check.";
                return View();
                }
            }
        }
        public IActionResult Login(string username, string password)
        {
            if(username is null && password is null)
            {
                return View();
            }
            else{
            // Validate username and password (e.g., against a database)
            if (IsValidUser(username, password))
            {
                // Authentication successful
                ViewBag.Username = username; 
                //HttpContext.Session.SetString("username", username);
                TempData["username"] = username;

                return RedirectToAction("Degree", "Degree", new { username = username });
            }
            else
            {
                // Authentication failed
                TempData["Message"] = "Invalid username or password.";
                return View();   
            }
          }
        }

        private bool IsValidUser(string username, string password)
        {
            // Your logic to validate username and password (e.g., query the database)
            // Return true if valid, false otherwise
            var userexist = _context.Users.Where(x => x.UserName == username && x.Password == password);
            if (userexist.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    public IActionResult Degree()
    {
        return View();
    }

    public IActionResult Graduate()
    {
        return View();
    }
    
    public IActionResult SelectCourses()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
