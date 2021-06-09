using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RCP.Controllers
{
    public class ReportController : Controller
    {
        // GET
        public Task<IActionResult> Index()
        {
            var commonDbContext = _context.Reports.Include(r => r.Client).Include(r => r.Worker);
            return View(await commonDbContext.ToListAsync());
        }
    }
}