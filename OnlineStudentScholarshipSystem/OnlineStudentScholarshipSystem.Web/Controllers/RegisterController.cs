using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineStudentScholarshipSystem.Web.Models;
using OnlineStudentScholarshipSystem.Web.ViewModels;

namespace OnlineStudentScholarshipSystem.Web.Controllers
{
    public class RegisterController : Controller
    {

        private AppDbContext _context;

        private readonly IMapper _mapper;

        public RegisterController(AppDbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]//Default
        public IActionResult studentRegister()
        {
            // Create a select list for education levels
            ViewBag.EducationLevelSelectStudent = new SelectList(new List<EducationLevelSelectList>()
            {
                new(){Data="Primary Education", Value="Primary Education"},
                new(){Data="Secondary Education", Value="Secondary Education"},
                new(){Data="High School", Value="High School"},
                new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                new(){Data="Master Degree", Value="Master Degree"},
                new(){Data="PhD", Value="PhD"},
                


            }, "Value", "Data");//view Data to user

            return View();
        }

        [HttpPost]
        public IActionResult studentRegister(StudentViewModel newStudent)
        {
            IActionResult result = null;
            // Create a select list for education levels
            ViewBag.EducationLevelSelectStudent = new SelectList(new List<EducationLevelSelectList>()
                {
                    new(){Data="Primary Education", Value="Primary Education"},
                    new(){Data="Secondary Education", Value="Secondary Education"},
                    new(){Data="High School", Value="High School"},
                    new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                    new(){Data="Master Degree", Value="Master Degree"},
                    new(){Data="PhD", Value="PhD"},

                }, "Value", "Data");//view Data to user

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Students.Add(_mapper.Map<Student>(newStudent));

                    _context.SaveChanges();

                    TempData["status"] = "Student successfully registered.";

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    // Check if the exception is due to a unique key violation (duplicate email)
                    if (ex.InnerException is SqlException sqlException &&
        sqlException.Message.Contains("Cannot insert duplicate key row") &&
        sqlException.Message.Contains("IX_Student_Email"))
                    {
                        TempData["status"] = "Email is already registered.";
                    }
                    else
                    {
                        // Handle other exceptions
                        TempData["status"] = "An error occurred while registering the student.";
                    }
                    return View();
                }
            }
            else
            {
                result = View();
            }
            return result;
        }


        [HttpGet]//Default
        public IActionResult officerRegister()
        {
            return View();
        }


        [HttpPost]
        public IActionResult officerRegister(OfficerViewModel newOfficer)
        {
            IActionResult result = null;

            if (ModelState.IsValid)
            {

                try
                {
                    // Check if the company already exists
                    var anyCompany = _context.Companies.Any(x => x.Name == newOfficer.CompanyName);

                    if (!anyCompany)
                    {
                        // Create a new company if it doesn't exist
                        CompanyViewModel newCompany =new CompanyViewModel();
                        newCompany.Name= newOfficer.CompanyName;
                        newCompany.Id = 0;
                        _context.Companies.Add(_mapper.Map<Company>(newCompany));
                    }

                    _context.Officers.Add(_mapper.Map<Officer>(newOfficer));

                    _context.SaveChanges();

                    TempData["status"] = "Officer successfully registered.";

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {

                    // Check if the exception is due to a unique key violation (duplicate email)
                    if (ex.InnerException is SqlException sqlException &&
        sqlException.Message.Contains("Cannot insert duplicate key row") &&
        sqlException.Message.Contains("IX_Officer_Email"))
                    {
                        TempData["status"] = "Email is already registered.";
                    }
                    else
                    {
                        // Handle other exceptions
                        TempData["status"] = "An error occurred while registering the student.";
                    }
                    return View();
                }

            }
            else
            {
                result = View();
            }

            return result;
        }
    }
}
