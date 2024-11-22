using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams
{
    public class TeamManageDTO
    {
        public int Id { get; set; }
        public string? CoachId { get; set; }
        public string? CreatorId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public int YearOfFoundation { get; set; }
        public virtual ICollection<ShortFootballerInfoDTO> Footballers { get; set; } = new List<ShortFootballerInfoDTO>();
    }
}
