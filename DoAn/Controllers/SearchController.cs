using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
