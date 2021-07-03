using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCP.DB;
using RCP.Models;
using RCP.ViewModel;

namespace RCP.Controllers
{
    public class ClientController : Controller
    {
        private readonly CommonDbContext _context;

        public ClientController(CommonDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async  Task<IActionResult> Create(CreateClientViewModel clientvm)
        {
            if (!ModelState.IsValid)
                return View(clientvm);

            _context.Clients.Add(new Client
            {
                Name = clientvm.ClientViewModel.Client.Name,
                Representant = clientvm.ClientViewModel.Client.Representant,
                ERP_ID = clientvm.ClientViewModel.Client.ERP_ID,
                Description = clientvm.ClientViewModel.Client.Description
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Report/Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var clientViewModel = new ClientViewModel();
            return View();
        }
    }
}
