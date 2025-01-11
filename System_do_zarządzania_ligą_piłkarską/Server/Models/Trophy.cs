using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class Trophy
    {
        public int Id { get; set; }
        public int? FootballerId {  get; set; }
        public string? CreatorId { get; set; }
        public int? TeamId {  get; set; }
        public int? LeagueSeasonId { get; set; }
        public string TrophyName { get; set; }
        public int? YearWon { get; set; }
        public TrophyOwner TrophyOwner { get; set; }
        public virtual Footballer? Footballer { get; set; }
        public virtual Team? Team { get; set; }
        public virtual LeagueSeason? LeagueSeason { get; set; }
        public virtual Image? Image { get; set; }
    }
}
