using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RCP.ViewModel
{
    public class ReportViewModel
    {
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string WorkerName { get; set; }
        public string StartDate { get; set; }
        public double ManHours { get; set; }
        public string Representant { get; set; }
        public int ReportID { get; set; }
        
        [BindProperty, DataType("month")] 
        public DateTime Month { get; set; }
    }
}