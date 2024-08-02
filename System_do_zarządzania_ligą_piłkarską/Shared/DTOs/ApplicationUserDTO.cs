using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class ApplicationUserDTO : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
        public virtual ICollection<FavouriteDTO> Favourites { get; set; } = new List<FavouriteDTO>();
    }
}
