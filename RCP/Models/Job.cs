
using System.ComponentModel.DataAnnotations;

namespace RCP.Models
{
    public class Job
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }    
        public double Salary { get; set; }
    }
}
