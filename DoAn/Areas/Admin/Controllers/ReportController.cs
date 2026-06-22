using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
