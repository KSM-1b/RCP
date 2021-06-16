using System;
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
        public async Task<IActionResult> Index()
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
                StartDate = x.StartDate.Date.ToString("dd/MM/yyyy"),
                ManHours = ((x.EndDate).Subtract(x.StartDate).TotalMinutes)/60,
                Representant = x.Client.Representant,
                ReportID = x.ID
            }).ToList();
            
            return View(reportViewModelsList);
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}