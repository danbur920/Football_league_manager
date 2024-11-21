using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches
{
    public class MatchFootballerDTO
    {
        public int Id { get; set; }
        public int FootballerId { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public int? ShirtNumber { get; set; }
        public bool IsStartingPlayer { get; set; }
    }
}
