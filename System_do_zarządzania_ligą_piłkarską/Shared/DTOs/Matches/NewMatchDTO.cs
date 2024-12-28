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
        [Required(ErrorMessage ="Gospodarz jest obowiązkowy.")]
        public int? HomeTeamId { get; set; }
        [Required(ErrorMessage ="Gość jest obowiązkowy.")]
        public int? AwayTeamId { get; set; }
        public int LeagueSeasonId { get; set; }
        [Required(ErrorMessage = "Sędzia jest obowiązkowy.")]
        public int? RefereeId { get; set; }
        [Required(ErrorMessage = "Kolejka jest obowiązkowa.")]
        public int? Round { get; set; }
        [Required(ErrorMessage = "Data meczu jest obowiązkowa.")]
        public DateOnly MatchDate { get; set; }
        [Required(ErrorMessage = "Godzina meczu jest obowiązkowa.")]
        public TimeOnly MatchTime { get; set; }
        [Required(ErrorMessage = "Nazwa stadionu jest obowiązkowa.")]
        public string? FootballStadium { get; set; }
    }
}




