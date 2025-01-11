using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class LeagueInfoDTO
    {
        public int Id { get; set; }
        public string LeagueMasterPrimaryId { get; set; } // główny zarządca ligi
        public string Name { get; set; }
        public string Country { get; set; }
        public Level? Level { get; set; }
        public virtual ImageDTO Image { get; set; }
        public virtual ApplicationUserDTO LeagueMasterPrimary { get; set; }
        [JsonIgnore]
        public virtual ICollection<LeagueSeasonDTO> LeagueSeasons { get; set; }
    }
}
