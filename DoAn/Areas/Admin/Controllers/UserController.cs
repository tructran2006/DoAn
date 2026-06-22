using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
