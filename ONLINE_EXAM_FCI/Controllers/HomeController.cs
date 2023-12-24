using Microsoft.AspNetCore.Mvc;
using ONLINE_EXAM_FCI.Models;
using System.Diagnostics;

namespace ONLINE_EXAM_FCI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var Name = HttpContext.Session.GetString("Name");
            //if(string.IsNullOrEmpty(Name))
            //{
            //    return RedirectToAction("Register", "Account");
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Exams()
        {
            return View();
        }
        public IActionResult Welcome()
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