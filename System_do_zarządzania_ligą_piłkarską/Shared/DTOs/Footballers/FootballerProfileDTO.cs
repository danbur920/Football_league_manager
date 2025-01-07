using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers
{
    public class FootballerProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }
        public int? ShirtNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public Position Position { get; set; }
        public int? Height { get; set; } 
        public int? Weight { get; set; }
        public string? TeamName { get; set; }
        public virtual ImageDTO Image { get; set; }
    }
}
