using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.Models
{
    public class TeamStatDTO
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int LeagueId { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalBalance { get; set; }
        public int Points { get; set; }
        public bool CurrentLeague { get; set; } // jeśli true to znaczy, że LeagueId wskazuje na aktualną ligę w jakiej gra zespół,
                                                // jeśli false to jest to liga, w której grał zespół w przeszłości
        public virtual LeagueDTO? League { get; set; }
        public virtual TeamDTO? Team { get; set; }
    }
}
