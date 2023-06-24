using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStudentScholarshipSystem.Web.Models;
using OnlineStudentScholarshipSystem.Web.ViewModels;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineStudentScholarshipSystem.Web.Controllers
{
    public class ScholarshipsController : Controller
    {

        private readonly IHttpContextAccessor contxt;

        private AppDbContext _context;

        private readonly IMapper _mapper;

        public ScholarshipsController(AppDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

            _mapper = mapper;

            contxt = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var scholarships = _context.Scholarships.ToList();

            var studentId = contxt.HttpContext.Session.GetInt32("studentId");

            var appliedScholarships = _context.ScholarshipApplications.Where(x => x.StudentId == studentId).ToList();

            ViewBag.appliedScholarships = appliedScholarships;

            return View(_mapper.Map<List<ScholarshipViewModel>>(scholarships));
        }

        public IActionResult Apply(int id)
        {

            string studentEmail = contxt.HttpContext.Session.GetString("email");

            var studentId = contxt.HttpContext.Session.GetInt32("studentId");

            // Create a new scholarship application
            ScholarshipApplicationViewModel newApplication = new ScholarshipApplicationViewModel();
            newApplication.Id = 0;
            newApplication.StudentId = (int)studentId;
            newApplication.ScholarshipId = id;
            _context.ScholarshipApplications.Add(_mapper.Map<ScholarshipApplication>(newApplication));

            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
