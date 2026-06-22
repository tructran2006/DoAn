using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
