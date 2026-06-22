using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
