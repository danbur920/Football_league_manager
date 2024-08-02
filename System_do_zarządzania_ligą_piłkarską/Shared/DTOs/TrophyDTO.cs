using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class TrophyDTO
    {
        public int Id { get; set; }
        public int? FootballerId { get; set; }
        public int? TeamId { get; set; }
        public string TrophyName { get; set; }
        public int? YearWon { get; set; }
        public TrophyOwner TrophyOwner { get; set; }
        public virtual FootballerDTO? Footballer { get; set; }
        public virtual TeamDTO? Team { get; set; }
    }

    public enum TrophyOwner
    {
        Footballer,
        Team
    }
}
