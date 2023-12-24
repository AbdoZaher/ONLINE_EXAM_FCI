using Microsoft.AspNetCore.Mvc;

namespace ONLINE_EXAM_FCI.Controllers
{
    public class LocalhostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
