using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCP.Models;
using RCP.ViewModel;

namespace RCP.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateClientViewModel clientvm)
        {

        }

    }
}
