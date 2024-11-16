using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees
{
    public class NewRefereeStatDTO
    {
        public int RefereeId { get; set; }
        public int LeagueSeasonId { get; set; }
    }
}
