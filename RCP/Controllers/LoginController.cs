using Microsoft.AspNetCore.Mvc;

namespace RCP.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}