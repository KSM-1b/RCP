using System;
using System.ComponentModel.DataAnnotations;

namespace RCP.ViewModel
{
    public class ReportViewModel
    {
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string WorkerName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan ManHours { get; set; }
        public string Representant { get; set; }
        public int ReportID { get; set; }
    }
}