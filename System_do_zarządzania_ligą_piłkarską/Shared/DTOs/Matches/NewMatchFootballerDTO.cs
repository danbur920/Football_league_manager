using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches
{
    public class NewMatchFootballerDTO
    {
        public int? MatchId { get; set; }
        [Required(ErrorMessage ="Zawodnik jest wymagany.")]
        public int? FootballerId { get; set; }
        public int? TeamId { get; set; }
        public bool IsStartingPlayer { get; set; }
        public bool IsSubstitutePlayer { get; set; }
    }
}
