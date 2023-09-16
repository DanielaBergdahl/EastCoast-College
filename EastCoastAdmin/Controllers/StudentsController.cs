using EastCoastAdmin.Models;
using EastCoastAdmin.Services;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace EastCoastAdmin.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger, IStudentService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.Find();
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id != 0)
            {
                var result = await _service.Find(id);

                return View(result);
            }
            else { return View(); }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id != 0)
            {
                var result = await _service.Find(id);
                return View(result);
            }
            else { return View(); }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel model, int id)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponse = _service.Update(content, id);
            model = await _service.AddCurrentAndEligibleCourses(model, id);

            return View(model);
        }

        public IActionResult Add(StudentViewModel model)
        {
            if(model.FirstName != null)
            { 
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var httpResponse = _service.Add(content);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseToStudent(int id)
        {
            if(id != 0)
            {
                int courseId = int.Parse(HttpContext.Request.Form["courseId"]);
                var studentCourse = new StudentCourse() { StudentId = id, CourseId = courseId };

                string data = JsonConvert.SerializeObject(studentCourse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                await _service.AddCourseToStudent(content, id);
            }

            return RedirectToAction("Edit", "Students", new {id = id});

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var result = await _service.Find(id);
                return View(result);
            }
            else { return View(); }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index", "Students");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
