using Microsoft.AspNetCore.Identity;
using System_do_zarządzania_ligą_piłkarską.Shared.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
