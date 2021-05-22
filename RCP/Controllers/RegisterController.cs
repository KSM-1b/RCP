using Microsoft.AspNetCore.Mvc;

namespace RCP.Controllers
{
    public class RegisterController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}