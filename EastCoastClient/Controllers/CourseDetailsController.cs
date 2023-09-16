using EastCoastAdmin.Models;
using EastCoastAdmin.Services;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace EastCoastAdmin.Controllers
{
    public class CourseDetailsController : Controller
    {
        private readonly ICourseService _service;
        private readonly ILogger<CourseDetailsController> _logger;

        public CourseDetailsController(ILogger<CourseDetailsController> logger, ICourseService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        public async Task<IActionResult> Index(int id)
        {
            if (id != 0) {
                var course = await _service.Find(id);
                return View(course);
            } else { return View(); }
        }

        public async Task<IActionResult> Edit(int id) 
        {
            if (id != 0)
            {
                var course = await _service.Find(id);
                return View(course);
            }
            else { return View(); }
        }

    }
}
