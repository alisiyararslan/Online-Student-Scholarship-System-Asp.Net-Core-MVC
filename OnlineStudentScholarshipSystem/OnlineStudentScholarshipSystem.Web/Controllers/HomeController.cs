using Microsoft.AspNetCore.Mvc;
using OnlineStudentScholarshipSystem.Web.Models;
using System.Diagnostics;

namespace OnlineStudentScholarshipSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor contxt;
        private readonly ILogger<HomeController> _logger;

        bool isFirstRun = true;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            contxt = httpContextAccessor; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}