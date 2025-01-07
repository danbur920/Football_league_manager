using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues
{
    public class LeagueSeasonDateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Season? Season { get; set; }
    }
}
