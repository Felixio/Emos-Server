using Microsoft.AspNetCore.Identity;

namespace Lgm.Emos.Core.Entities
{
    public class IdentityAppUser : IdentityUser
    {
        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}