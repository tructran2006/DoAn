using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
