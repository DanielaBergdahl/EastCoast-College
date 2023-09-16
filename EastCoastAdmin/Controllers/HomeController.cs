using EastCoastAdmin.Models;
using EastCoastAdmin.Services;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EastCoastAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICourseService service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        
        public IActionResult Index()
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