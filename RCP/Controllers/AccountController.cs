using Microsoft.AspNetCore.Mvc;

namespace RCP.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}