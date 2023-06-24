using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStudentScholarshipSystem.Web.Models;
using OnlineStudentScholarshipSystem.Web.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineStudentScholarshipSystem.Web.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IHttpContextAccessor contxt;

        private AppDbContext _context;

        private readonly IMapper _mapper;

        public DashboardController(AppDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

            _mapper = mapper;

            contxt = httpContextAccessor;
        }

        // GET: Dashboard/Index
        public IActionResult Index()
        {
            if (contxt.HttpContext.Session.GetString("userType")=="student")
            {

                string studentEmail = contxt.HttpContext.Session.GetString("email");

                var studentId = contxt.HttpContext.Session.GetInt32("studentId");
                
                // Fetch scholarship applications for the student
                var scholarshipApplications = _context.ScholarshipApplications.Where(x => x.StudentId == studentId);

                var scholarships = _context.Scholarships
                    .Join(
                        scholarshipApplications,
                        scholarships => scholarships.Id,
                        scholarshipApplications => scholarshipApplications.ScholarshipId,
                        (scholarships, scholarshipApplications) => new
                        {
                            Scholarships = scholarships,
                            ScholarshipApplications = scholarshipApplications
                        }
                    )
                    .Select(joinedData => joinedData.Scholarships)
                    .ToList();

                return View(_mapper.Map<List<ScholarshipViewModel>>(scholarships));
            }
            else
            {
                int officerCompanyId = (int)contxt.HttpContext.Session.GetInt32("companyId");

                var company = _context.Companies.Where(x => x.Id == officerCompanyId).Single();

                var scholarships = _context.Scholarships.Where(x => x.Foundation == company.Name);

                return View(_mapper.Map<List<ScholarshipViewModel>>(scholarships));
            }
            
        }

        public IActionResult remove(int id)
        {
            var scholarship = _context.Scholarships.Find(id);

            _context.Scholarships.Remove(scholarship);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]//Default
        public IActionResult add()
        {
            // Populate the education level select list for the view
            ViewBag.EducationLevelSelect = new SelectList(new List<EducationLevelSelectList>()
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
        public IActionResult add(ScholarshipViewModel newScholarship)
        {

            IActionResult result = null;

            if (ModelState.IsValid)
            {
                try
                {

                    newScholarship.PublishDate = DateTime.Now;

                    int officerId = (int)contxt.HttpContext.Session.GetInt32("officerId");

                    var companyName = _context.Officers.Where(x => x.Id == officerId).Single().CompanyName;

                    newScholarship.Foundation = companyName;

                    _context.Scholarships.Add(_mapper.Map<Scholarship>(newScholarship));

                    _context.SaveChanges();

                    TempData["status"] = "Scholarship successfully added.";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    result = View();
                }

            }
            else
            {
                result = View();

            }

            ViewBag.EducationLevelSelect = new SelectList(new List<EducationLevelSelectList>()
                {
                    new(){Data="Primary Education", Value="Primary Education"},
                    new(){Data="Secondary Education", Value="Secondary Education"},
                    new(){Data="High School", Value="High School"},
                    new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                    new(){Data="Master Degree", Value="Master Degree"},
                    new(){Data="PhD", Value="PhD"},


                }, "Value", "Data");//view Data to user

            return result;
        }

        [HttpGet]
        public IActionResult update(int id)
        {
            var scholarship = _context.Scholarships.Find(id);

            ViewBag.EducationLevelSelect = new SelectList(new List<EducationLevelSelectList>()
            {
                new(){Data="Primary Education", Value="Primary Education"},
                new(){Data="Secondary Education", Value="Secondary Education"},
                new(){Data="High School", Value="High School"},
                new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                new(){Data="Master Degree", Value="Master Degree"},
                new(){Data="PhD", Value="PhD"},


            }, "Value", "Data");//view Data to user
            return View(_mapper.Map<ScholarshipViewModel>(scholarship));
        }

        [HttpPost]
        public IActionResult update(ScholarshipViewModel updateScholarship)
        {
            IActionResult result = null;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Scholarships.Update(_mapper.Map<Scholarship>(updateScholarship));

                    _context.SaveChanges();

                    TempData["status"] = "Scholarship successfully updated.";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    result = View();
                }

            }
            else
            {
                result = View();

            }

            ViewBag.EducationLevelSelect = new SelectList(new List<EducationLevelSelectList>()
                {
                    new(){Data="Primary Education", Value="Primary Education"},
                    new(){Data="Secondary Education", Value="Secondary Education"},
                    new(){Data="High School", Value="High School"},
                    new(){Data="Bachelor's Degree", Value="Bachelor's Degree"},
                    new(){Data="Master Degree", Value="Master Degree"},
                    new(){Data="PhD", Value="PhD"},


                }, "Value", "Data");//view Data to user

            return result;
        }

        public IActionResult withdrawApplication(int id)
        {
            string studentEmail = contxt.HttpContext.Session.GetString("email");

            var studentId = contxt.HttpContext.Session.GetInt32("studentId");

            var scholarshipApplication = _context.ScholarshipApplications.Where(x => x.ScholarshipId == id && x.StudentId == studentId).Single();

            _context.ScholarshipApplications.Remove(scholarshipApplication);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult applicants(int id)
        {
            var scholarshipName = _context.Scholarships.Where(x => x.Id == id).Single().Name;

            ViewBag.ScholarshipName = scholarshipName;

            var scholarshipApplications = _context.ScholarshipApplications.Where(x => x.ScholarshipId == id);

            var students = _context.Students
                .Join(
                    _context.ScholarshipApplications,
                    students => students.Id,
                    scholarshipApplications => scholarshipApplications.StudentId,
                    (students, scholarshipApplications) => new
                    {
                        Students = students,
                        ScholarshipApplications = scholarshipApplications
                    }
                )
                .Where(x => x.ScholarshipApplications.ScholarshipId == id)
                .Select(joinedData => joinedData.Students)
                .ToList();

            return View(_mapper.Map<List<StudentViewModel>>(students));
        }



    }
}
