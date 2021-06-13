using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCP.Models
{
    public class Report
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Client Client { get; set; }
    }
}
