using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
