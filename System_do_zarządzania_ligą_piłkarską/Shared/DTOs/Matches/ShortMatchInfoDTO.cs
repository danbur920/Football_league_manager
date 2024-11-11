using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches
{
    public class ShortMatchInfoDTO
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public int GoalsHome { get; set; }
        public int GoalsAway { get; set; }
        public bool IsFinished { get; set; }
        public int? Result { get; set; }
        public DateOnly? MatchDate { get; set; }
        public TimeOnly? MatchTime { get; set; }
        public virtual TeamDTO HomeTeam { get; set; }
        public virtual TeamDTO AwayTeam { get; set; }
    }
}
