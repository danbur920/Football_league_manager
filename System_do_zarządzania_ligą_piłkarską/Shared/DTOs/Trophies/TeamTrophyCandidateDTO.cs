using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies
{
    public class TeamTrophyCandidateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
