using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class Trophy
    {
        public int Id { get; set; }
        public int? FootballerId {  get; set; }
        public int? TeamId {  get; set; }
        public string TrophyName { get; set; }
        public int? YearWon { get; set; }
        public TrophyOwner TrophyOwner { get; set; }
        public virtual Footballer? Footballer { get; set; }
        public virtual Team? Team { get; set; }
    }

    public enum TrophyOwner
    {
        Footballer,
        Team
    }
}
