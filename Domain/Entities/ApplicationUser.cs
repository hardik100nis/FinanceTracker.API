using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Add custom properties here if needed later
        public string FullName { get; set; }

    }
}
