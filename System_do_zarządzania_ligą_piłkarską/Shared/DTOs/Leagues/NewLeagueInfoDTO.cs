using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues
{
    public class NewLeagueInfoDTO
    {
        [Required(ErrorMessage = "Nazwa ligi jest obowiązkowa.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kraj jest obowiązkowy.")]
        public string Country { get; set; }
        public Level? Level { get; set; }
    }
}
