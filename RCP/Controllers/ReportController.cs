using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            List<ReportViewModel> vmreports = reports.Select(report => new ReportViewModel
            {
                Report = report,
                ManHours = manHours.GetManHours(report.StartDate, report.EndDate),
            }).ToList();

            return vmreports;
        }

        private async Task<ReportViewModel> ConvertedReport(int id)
        {
            var reports = await ConvertedReports();

            return reports.Where(x => x.Report.ID == id).FirstOrDefault();
        }

        // GET
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await ConvertedReports());
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Client> clients = await _context.Clients.ToListAsync();
            IEnumerable<Worker> workers = await _context.Workers.ToListAsync();
            
            ViewBag.ClientEnums = (clients.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }));

            ViewBag.WorkerEnums = (workers.Select(x => new SelectListItem()
            {
                Text = x.FirstName,
                Value = x.ID.ToString()
            }));

            var ReportViewModel = new ReportViewModel();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await ConvertedReports();

            return View(data.Where(x => x.Report.ID == id).FirstOrDefault());
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await ConvertedReport(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateReportViewModel reportvm)
        {
            if (!ModelState.IsValid)
                return View(reportvm);

            _context.Reports.Add(new Report
            {
                Description = reportvm.ReportViewModel.Report.Description,
                Worker = await _context.Workers.Where(x => x.ID == reportvm.ReportViewModel.Report.WorkerID).FirstOrDefaultAsync(),
                Client = await _context.Clients.Where(x => x.ID == reportvm.ReportViewModel.Report.ClientID).FirstOrDefaultAsync(),
                StartDate = reportvm.ReportViewModel.Report.StartDate,
                EndDate = reportvm.ReportViewModel.Report.EndDate
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(ReportViewModel reportvm)
        {
            if (!ModelState.IsValid)
                return View(reportvm);

            var reports = await GetReports();

            var data = reports.Where(x => x.ID == reportvm.Report.ID).FirstOrDefault();

            data.Description = reportvm.Report.Description;
            data.StartDate = reportvm.Report.StartDate;
            if (data.EndDate > data.StartDate)
                data.EndDate = reportvm.Report.EndDate;
            else
                return View(reportvm);

            data.Worker.FirstName = reportvm.Report.Worker.FirstName;
            data.Worker.LastName = reportvm.Report.Worker.LastName;
            data.Client.Representant = reportvm.Report.Client.Representant;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}