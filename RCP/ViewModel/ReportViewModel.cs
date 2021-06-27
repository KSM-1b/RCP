using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using RCP.Models;

namespace RCP.ViewModel
{
    public class ReportViewModel
    {
        public Report Report { get; set; }
        public double ManHours { get; set; }
        public int ReportID { get; set; }
    }
}