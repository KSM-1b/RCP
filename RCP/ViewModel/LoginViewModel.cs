using System.ComponentModel.DataAnnotations;

namespace RCP.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }   
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }   
        
        //TODO: Create Cookie, to implement login remember
        [Display(Name = "Remember Me")]   
        public bool RememberMe { get; set; }   
    }
}