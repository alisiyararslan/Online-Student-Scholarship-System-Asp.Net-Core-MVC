using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStudentScholarshipSystem.Web.Models;
using OnlineStudentScholarshipSystem.Web.ViewModels;

namespace OnlineStudentScholarshipSystem.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly IHttpContextAccessor contxt;

        private AppDbContext _context;

        private readonly IMapper _mapper;



        public LoginController(AppDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

            _mapper = mapper;

            contxt = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]//Default
        public IActionResult studentLogin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult studentLogin(StudentViewModel newStudent)
        {
            // Check if email and password are provided
            if (newStudent.Password != null && newStudent.Email != null)
            {
                // Check if a student exists with the provided email and password
                var anyStudent = _context.Students.Any(x => x.Email == newStudent.Email && x.Password == newStudent.Password);

                // Fetch student ID
                var studentId = _context.Students.Where(x => x.Email == newStudent.Email).Single().Id;

                if (anyStudent)
                {
                    
                    TempData["status"] = "successfully logged in";


                    contxt.HttpContext.Session.SetString("email", newStudent.Email);
                    contxt.HttpContext.Session.SetString("password", newStudent.Password);
                    contxt.HttpContext.Session.SetString("userType", "student");
                    contxt.HttpContext.Session.SetInt32("studentId", studentId);

                    return RedirectToAction( "Index","Home");
                }
                else
                {
                    TempData["status"] = "There is no student with these email and password.";

                }
            }
            return View();
        }

        [HttpGet]//Default
        public IActionResult officerLogin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult officerLogin(OfficerViewModel newOfficer)
        {
            // Check if email and password are provided
            if (newOfficer.Password != null && newOfficer.Email != null)
            {
                // Check if an officer exists with the provided email and password
                var anyOfficer = _context.Officers.Any(x => x.Email == newOfficer.Email && x.Password == newOfficer.Password);


                if (anyOfficer)
                {

                    TempData["status"] = "successfully logged in";

                    var companyName = _context.Officers.Where(x => x.Email == newOfficer.Email).Single().CompanyName;

                    var officerId = _context.Officers.Where(x => x.Email == newOfficer.Email).Single().Id;

                    var companyId = _context.Companies.Where(x => x.Name == companyName).Single().Id;

                    // Store user session information
                    contxt.HttpContext.Session.SetString("email", newOfficer.Email);
                    contxt.HttpContext.Session.SetString("password", newOfficer.Password);
                    contxt.HttpContext.Session.SetInt32("companyId", companyId);
                    contxt.HttpContext.Session.SetString("userType", "officer");
                    contxt.HttpContext.Session.SetInt32("officerId", officerId);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["status"] = "There is no officer with these email and password.";
                    

                }
            }
            return View();
        }

        public IActionResult logout()
        {
            
            // Clear user session information
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("password");
            
            if (contxt.HttpContext.Session.GetString("userType") == "officer")
            {
                HttpContext.Session.Remove("companyId");
                HttpContext.Session.Remove("officerId");
            }
            else
            {
                HttpContext.Session.Remove("studentId");
                
            }
            HttpContext.Session.Remove("userType");



            return RedirectToAction("Index", "Home");
        }
    }
}
