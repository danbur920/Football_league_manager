using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class RefereeStat
    {
        public int Id { get; set; }
        public int RefereeId { get; set; }
        public int LeagueSeasonId { get; set; }
        public int RefereedMatches { get; set; }
        public int YellowCardsGiven {  get; set; }
        public int RedCardsGiven {  get; set; }
        public int PenaltiesAwarded { get; set; }
        public virtual Referee? Referee { get; set; }
        public virtual LeagueSeason? LeagueSeason { get; set; }
    }
}
