using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies
{
    public class NewTrophyDTO
    {
        public int? FootballerId { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueSeasonId { get; set; }
        [Required(ErrorMessage ="Nazwa trofeum jest wymagana.")]
        public string TrophyName { get; set; }
        public int? YearWon { get; set; }
        [Required(ErrorMessage = "Posiadacz trofeum jest wymagany.")]
        public TrophyOwner? TrophyOwner { get; set; }
    }
}
