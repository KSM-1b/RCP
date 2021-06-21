using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModel
{
    public class CreateReportViewModel
    {
        public string Description { get; set; }
        public string ClientName { get; set; }
        public int WorkerID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Representant { get; set; }
      
    }
}


