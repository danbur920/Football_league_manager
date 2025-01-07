using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using static System.Net.Mime.MediaTypeNames;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees
{
    public class RefereeInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string? Level { get; set; }
        public virtual ImageDTO? Image { get; set; }
    }
}
