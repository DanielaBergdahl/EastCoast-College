using EastCoastAdmin.Models;
using EastCoastAdmin.Services;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace EastCoastAdmin.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _service;
        private readonly ILogger<TeachersController> _logger;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _service.Find();
            return View(teachers);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id != 0)
            {
                var teacher = await _service.Find(id);
                return View(teacher);
            }
            else { return View(); }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id != 0)
            {
                var teacher = await _service.Find(id);
                return View(teacher);
            }
            else { return View(); }
        }

        [HttpPost]
        public IActionResult Edit(TeacherViewModel model, int id)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponse = _service.Update(content, id);

            return View();
        }

        public IActionResult Add(TeacherViewModel model)
        {
            if(model.FirstName != null)
            { 
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var httpResponse = _service.Add(content);
                Thread.Sleep(1000);
                return RedirectToAction("Index", "Teachers");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id) 
        {
        
            if (id != 0)
            {
                var teacher = await _service.Find(id);
                return View(teacher);
            }
            else { return View(); }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            //var httpResponse = await _service.Delete(id);
            _service.Delete(id);
            return RedirectToAction("Index", "Teachers");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
