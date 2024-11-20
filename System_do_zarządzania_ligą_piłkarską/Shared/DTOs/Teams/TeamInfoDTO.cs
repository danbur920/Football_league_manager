using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams
{
    public class TeamInfoDTO
    {
        public int Id { get; set; }
        public string? CoachId { get; set; }
        public string? CreatorId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public int YearOfFoundation { get; set; }
        [NotMapped]
        public bool HasCoach { get; set; }
        [NotMapped]
        public ShortCoachInfoDTO Coach { get; set; } = new ShortCoachInfoDTO();
    }
}
