using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers
{
    public class NewFootballerDTO
    {
        public int? TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ShirtNumber { get; set; }
        public Position Position { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
    }
}
