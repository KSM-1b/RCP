using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCP.DB;
using RCP.Models;
using RCP.ViewModel;

namespace RCP.Controllers
{
    public class ReportController : Controller
    {
        
        private readonly CommonDbContext _context;
        private List<ReportViewModel> _reportViewModel;

        public ReportController(CommonDbContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            List<Report> reportList = _context.Reports
                .Include(x=>x.Client)
                .Include(y=>y.Worker)
                .ToList();
            
            
            List<ReportViewModel> reportViewModelsList = reportList.Select(x => new ReportViewModel
            {
                Description = x.Description,
                ClientName = x.Client.Name,
                WorkerName = x.Worker.FirstName + " " +x.Worker.LastName,
                StartDate = x.StartDate,
            }).ToList();
            
            
            return View(reportViewModelsList);
        }
    }
}