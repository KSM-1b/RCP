using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCP.DB;

namespace RCP.Controllers
{
    public class ReportController : Controller
    {
        
        private readonly CommonDbContext _context;

        public ReportController(CommonDbContext context)
        {
            _context = context;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            var commonDbContext = _context.Reports.
                Include(r => r.Client).
                Include(r => r.Worker);
            return View(await commonDbContext.ToListAsync());
        }
    }
}