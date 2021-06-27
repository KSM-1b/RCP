using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RCP.ViewModel
{
    public class ReportViewModel
    {
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double ManHours { get; set; }
        public string Representant { get; set; }
        public int ReportID { get; set; }
    }
}