using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images
{
    public class ImageDTO
    {
        public string Path { get; set; }
        public int? FootballerId { get; set; }
        public int? TeamId { get; set; }
        public int? RefereeId { get; set; }
        public int? LeagueId { get; set; }
    }
}
