using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
