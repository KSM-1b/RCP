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
        
        public Worker Worker { get; set; }
        public int WorkerID { get; set; }
        
        public Client Client { get; set; }
        public int ClientID { get; set; }
    }
}
