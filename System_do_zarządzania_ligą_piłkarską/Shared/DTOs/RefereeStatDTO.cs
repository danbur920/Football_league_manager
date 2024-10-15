using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class RefereeStatDTO
    {
        public int Id { get; set; }
        public int RefereeId { get; set; }
        public int LeagueId { get; set; }
        public int RefereedMatches { get; set; }
        public int YellowCardsGiven { get; set; }
        public int RedCardsGiven { get; set; }
        public int PenaltiesAwarded { get; set; }
        public int FoulsCalled { get; set; }
        [JsonIgnore]
        public virtual RefereeDTO? Referee { get; set; }
        public virtual LeagueDTO? League { get; set; }
    }
}
