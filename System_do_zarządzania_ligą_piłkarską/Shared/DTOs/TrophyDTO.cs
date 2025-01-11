using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class TrophyDTO
    {
        public int Id { get; set; }
        public int? FootballerId { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueSeasonId { get; set; }
        public string TrophyName { get; set; }
        public int? YearWon { get; set; }
        public TrophyOwner TrophyOwner { get; set; }
        public FootballerDTO? Footballer { get; set; }
        public TeamDTO? Team { get; set; }
        public ImageDTO? Image { get; set; }
    }
}
