using System;
 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class RefereeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string? Level { get; set; }
        public int TotalYellowCardsGiven { get; set; }
        public int TotalRedCardsGiven { get; set; }
        public int TotalRefereedMatches { get; set; }
        public int TotalPenaltiesAwarded { get; set; }
        public virtual ImageDTO Image {  get; set; }
        public virtual ICollection<RefereeStatDTO> RefereeStats { get; set; } = new List<RefereeStatDTO>();
    }
}
