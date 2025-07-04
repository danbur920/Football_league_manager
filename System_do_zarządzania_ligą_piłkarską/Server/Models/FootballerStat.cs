﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class FootballerStat
    {
        public int Id { get; set; }
        public int FootballerId { get; set; }
        public int LeagueSeasonId { get; set; }
        public int TeamStatId { get; set; }
        public int MatchesPlayed { get; set; }
        public int StartingAppearances {  get; set; }
        public int SubstituteAppearances {  get; set; }
        public int Goals {  get; set; }
        public int OwnGoals {  get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public virtual Footballer? Footballer { get; set; }
        public virtual LeagueSeason? LeagueSeason { get; set; }
        public virtual TeamStat? TeamStat { get; set; }
    }
}
