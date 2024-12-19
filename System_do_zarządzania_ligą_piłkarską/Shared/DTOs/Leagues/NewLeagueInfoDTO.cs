using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues
{
    public class NewLeagueInfoDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public Level? Level { get; set; }
    }
}
