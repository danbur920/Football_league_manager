using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class LeagueSeasonDTO
    {
        public int Id { get; set; }
        public int LeagueInfoId { get; set; }
        public string? LeagueMasterSecondaryId { get; set; }
        public Season? Season { get; set; }
        public int MatchesPlayed { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
        public virtual LeagueInfoDTO LeagueInfo { get; set; }
        public virtual ApplicationUserDTO LeagueMasterSecondary { get; set; }
    }
}
