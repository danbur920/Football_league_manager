using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches
{
    public class NewMatchDTO
    {
        [Required(ErrorMessage ="To pole jest obowiązkowe.")]
        public int HomeTeamId { get; set; }
        [Required(ErrorMessage ="To pole jest obowiązkowe.")]
        public int AwayTeamId { get; set; }

        public int LeagueId { get; set; }

        public int RefereeId { get; set; }
        [Required(ErrorMessage = "To pole jest obowiązkowe.")]
        public int Round { get; set; }
        [Required(ErrorMessage = "To pole jest obowiązkowe.")]
        public DateOnly MatchDate { get; set; }
        [Required(ErrorMessage = "To pole jest obowiązkowe.")]
        public TimeOnly MatchTime { get; set; }
    }
}
