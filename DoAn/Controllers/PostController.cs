using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
