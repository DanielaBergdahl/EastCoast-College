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



        [HttpPost]
        public async Task<IActionResult> AddCourseToStudent(int courseId)
        {
            if(courseId != 0)
            {
                int studentId = int.Parse(HttpContext.Request.Form["studentId"]);
                var studentCourse = new StudentCourse() { StudentId = studentId, CourseId = courseId };

                string data = JsonConvert.SerializeObject(studentCourse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                await _service.AddCourseToStudent(content, studentId);
            }

            return RedirectToAction("Index", "Home");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
