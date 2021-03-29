
namespace RCP.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Job Job { get; set; }
        public int JobID { get; set; }
        public User User { get; set; }
        public string UserID { get; set; }
    }
}
