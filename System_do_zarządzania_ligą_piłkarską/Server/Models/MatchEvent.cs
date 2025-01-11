using System.Text.Json.Serialization;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? PrimaryFootballerId { get; set; } // strzelec gola,
                                                      // żółta/czerwona kartka,
                                                      // wykonawca rzutu karnego,
                                                      // zawodnik wchodzący
        public int? SecondaryFootballerId { get; set; } // asystent gola,
                                                        // zawodnik schodzący
        public int? TeamId { get; set; } 
        public int? RefereeId { get; set; }
        public int? LeagueSeasonId { get; set; }
        public int? Minute {  get; set; }
        public string? Description { get; set; }
        public EventType EventType { get; set; }
        [JsonIgnore]
        public Match? Match { get; set; }
    }
}