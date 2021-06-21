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

        // GET
        public async Task<IActionResult> Index()
        {
            List<Report> reportList = _context.Reports
                .Include(x => x.Client)
                .Include(y => y.Worker)
                .ToList();

            var manHours = new ManHours();

            List<ReportViewModel> reportViewModelsList = reportList.Select(x => new ReportViewModel
            {
                Description = x.Description,
                ClientName = x.Client.Name,
                WorkerName = x.Worker.FirstName + " " + x.Worker.LastName,
                StartDate = x.StartDate.Date.ToString("dd/MM/yyyy"),
                ManHours = manHours.GetManHours(x.StartDate, x.EndDate),
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

        public IActionResult Create()
        {
            return View();
        }
    }
}