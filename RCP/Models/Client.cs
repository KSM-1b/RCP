
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCP.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ERP_ID { get; set; }
        public string Description { get; set; }
        public string Representant { get; set; }
        private ICollection<Report> Reports { get; set; }
    }
}
