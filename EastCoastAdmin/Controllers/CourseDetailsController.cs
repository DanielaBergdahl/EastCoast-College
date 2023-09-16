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

        [HttpPost]
        public IActionResult Edit(CourseViewModel model, int id)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponse = _service.Update(content, id);

            return View();
        }

        public IActionResult Add(CourseViewModel model)
        {
            if (model.CourseNumber != 0)
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                _service.Add(content);
                Thread.Sleep(1000);
                return RedirectToAction("Index","Courses"); 
                //var httpResponse = _service.Add(content);
            }
            return View();

        }

    }
}
