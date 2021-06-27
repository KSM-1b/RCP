using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RCP.DB;
using RCP.Helpers;
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

        private async Task<List<Report>> GetReports()
        {
            List<Report> reportList = await _context.Reports
                                        .Include(x => x.Client)
                                        .Include(y => y.Worker)
                                        .ToListAsync();
            return reportList;
        }

        private async Task<List<ReportViewModel>> ConvertedReports()
        {
            List<Report> reports = await GetReports();
            var manHours = new ManHours();

            List<ReportViewModel> vmreports = reports.Select(x => new ReportViewModel
            {
                Description = x.Description,
                ClientName = x.Client.Name,
                FirstName = x.Worker.FirstName,
                LastName = x.Worker.LastName,
                StartDate = x.StartDate.Date,
                EndDate = x.EndDate.Date,
                ManHours = manHours.GetManHours(x.StartDate, x.EndDate),
                Representant = x.Client.Representant,
                ReportID = x.ID
            }).ToList();

            return vmreports;
        }

        private async Task<ReportViewModel> ConvertedReport(int id)
        {
            var reports = await ConvertedReports();

            return reports.Where(x => x.ReportID == id).FirstOrDefault();
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await ConvertedReports());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await ConvertedReports();

            return View(data.Where(x => x.ReportID == id).FirstOrDefault());
        }

        public IActionResult Details(int id)
        {
            return View(ConvertedReport(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReportViewModel report)
        {
            if (!ModelState.IsValid)
                return View(report);

            var data = await _context.Reports.Where(x => x.ID == report.ReportID).FirstOrDefaultAsync();

            data.Description = report.Description;
            data.StartDate = report.StartDate;
            if (data.EndDate > data.StartDate)
            {
                data.EndDate = report.EndDate;
            }
            else
            {
                return View(report);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}