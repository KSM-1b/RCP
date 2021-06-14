
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RCP.Models
{
    public class Worker
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public Job Job { get; set; }
        public int JobID { get; set; }
        
        public IdentityUser User { get; set; }
        public string UserID { get; set; }

        private ICollection<Report> Reports { get; set; }
    }
}
