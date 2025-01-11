using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues
{
    public class ShortLeagueInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Level? Level { get; set; }
        public virtual ImageDTO? Image { get; set; }
    }
}
