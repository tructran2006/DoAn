using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
