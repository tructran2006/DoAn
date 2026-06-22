using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
