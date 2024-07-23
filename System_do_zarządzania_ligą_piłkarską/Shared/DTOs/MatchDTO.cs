using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.Models
{
    public class MatchDTO
    {
        public int Id { get; set; }
        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }
        public int LeagueId { get; set; }
        public int RefereeId { get; set; }
        public int Round { get; set; }
        public string FootballStadium { get; set; } // nazwa stadionu gospodarza
        public int GoalsHome { get; set; }
        public int GoalsAway { get; set; }
        public int GoalsCount { get; set; }
        public bool IsFinished { get; set; }
        public int? Result { get; set; }
        public DateOnly? MatchDate { get; set; }
        public TimeSpan? MatchTime { get; set; }
        public virtual LeagueDTO League { get; set; }
        public virtual Referee Referee { get; set; }
        public virtual TeamDTO HomeTeam { get; set; }
        public virtual TeamDTO AwayTeam { get; set; }
    }
}
