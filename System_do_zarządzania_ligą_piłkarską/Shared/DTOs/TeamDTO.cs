﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string? CoachId { get; set; } // odnosi się do trenera - na potrzeby lepszego nazewnictwa użyłem CoachId zamiast UserId
        public string? CreatorId { get; set; } // odnosi się do osoby, która stworzyła drużynę (ta osoba będzie mogła nadawać uprawnienia trenerskie)
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public int YearOfFoundation { get; set; }
        public virtual ImageDTO Image {  get; set; }
        public virtual ApplicationUserDTO? Coach { get; set; }
        [JsonIgnore]
        public virtual ICollection<MatchDTO> HomeMatches { get; set; } = new List<MatchDTO>();
        [JsonIgnore]
        public virtual ICollection<MatchDTO> AwayMatches { get; set; } = new List<MatchDTO>();
        [JsonIgnore]
        public virtual ICollection<TeamStatDTO> TeamStats { get; set; } = new List<TeamStatDTO>();
        [JsonIgnore]
        public virtual ICollection<TrophyDTO> Trophies { get; set; } = new List<TrophyDTO>();
        //public virtual ICollection<FootballerDTO> Footballers { get; set; } = new List<FootballerDTO>();

        public int LeagueId { get; set; }
    }
}
