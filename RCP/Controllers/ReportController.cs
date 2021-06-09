using Microsoft.AspNetCore.Mvc;

namespace RCP.Controllers
{
    public class ReportController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}