using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues
{
    public class NewLeagueSeasonDTO
    {
        public int? LeagueInfoId { get; set; }
        public string? LeagueMasterId { get; set; } // zarządca ligi
        public Season? Season { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
    }
}
