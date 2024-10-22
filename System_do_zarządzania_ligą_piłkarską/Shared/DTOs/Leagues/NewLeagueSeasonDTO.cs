using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues
{
    public class NewLeagueSeasonDTO
    {
        public Season? Season { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
    }
    public enum Season
    {
        _Brak,
        _2023,
        _2023_2024,
        _2024,
        _2024_2025,
        _2025,
        _2025_2026,
        _2026,
        _2026_2027,
        _2027,
        _2027_2028,
        _2028,
        _2028_2029,
        _2029,
        _2029_2030,
        _2030
    }
}
