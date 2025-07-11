using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.API.Application.DTOs
{
    public class RegisterDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
