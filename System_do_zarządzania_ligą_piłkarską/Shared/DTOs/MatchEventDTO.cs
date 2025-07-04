﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class MatchEventDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? PrimaryFootballerId { get; set; } // strzelec gola (w tym również gol samobójczy),
                                                      // żółta/czerwona kartka,
                                                      // wykonawca rzutu karnego,
                                                      // zawodnik schodzący
        public int? SecondaryFootballerId { get; set; } // asystent gola,
                                                        // zawodnik wchodzący
        public int? TeamId { get; set; } 
        public int? RefereeId { get; set; }
        public int? LeagueSeasonId { get; set; }
        public int? Minute { get; set; }
        public string? Description { get; set; }
        public EventType EventType { get; set; }
        [JsonIgnore]
        public virtual MatchDTO? Match { get; set; }
    }
}

