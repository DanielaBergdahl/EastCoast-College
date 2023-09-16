using EastCoastAdmin.Models;
using EastCoastAdmin.Services;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EastCoastAdmin.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ILogger<CoursesController> logger, ICourseService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index(string categorySearchString)
        {
            ViewData["CurrentCategoryFilter"] = categorySearchString;
            var courses = await _service.Find();
            courses = courses.OrderBy(c => c.CourseNumber);
            

            if (!String.IsNullOrEmpty(categorySearchString))
                courses = courses.Where(s => s.Category.Contains(categorySearchString)); //Category filter
            return View(courses);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
