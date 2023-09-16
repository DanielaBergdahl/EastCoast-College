using EastCoastAdmin.Models;
using EastCoastAdmin.Services;
using EastCoastAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Web;


namespace EastCoastAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly ILogger<HomeController> _logger;
        private IHttpContextAccessor Accessor;

        public HomeController(ILogger<HomeController> logger, ICourseService courseService, IStudentService studentService, IHttpContextAccessor _accessor)
        {
            _logger = logger;
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this.Accessor = _accessor;
        }



        [HttpPost]
        public IActionResult AddCookie(string name)
        {
            if (name != null)
            {
                //Set the Expiry date of the Cookie.
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);

                //Create a Cookie with a suitable Key and add the Cookie to Browser.
                Response.Cookies.Append("Name", name, option);

            }
            TempData["Message"] = name != null ? name : "undefined";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ReadCookie()
        {
            //Fetch the Cookie value using its Key.
            string name = this.Accessor.HttpContext.Request.Cookies["Name"];

            TempData["Message"] = name != null ? name : "undefined";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCookie()
        {
            //Delete the Cookie from Browser.
            Response.Cookies.Delete("Name");

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Index(string categorySearchString)
        {
            //cookie for "login"
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";

            ViewData["CurrentCategoryFilter"] = categorySearchString;
            var courses = await _courseService.Find();
            courses = courses.OrderBy(c => c.CourseNumber);


            if (!String.IsNullOrEmpty(categorySearchString))
                courses = courses.Where(s => s.Category.Contains(categorySearchString)); //Category filter
            return View(courses);
        }


        [HttpPost]
        public async Task<IActionResult> SignUpForCourse()
        {
            if (HttpContext.Request.Form["studentId"] != "")
            { 
                int studentId = int.Parse(HttpContext.Request.Form["studentId"]);
                int courseId = int.Parse(HttpContext.Request.Form["CourseId"]);
                var studentCourse = new StudentCourse() { StudentId = studentId, CourseId = courseId };

                string data = JsonConvert.SerializeObject(studentCourse);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                await _studentService.AddCourseToStudent(content, studentId);
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