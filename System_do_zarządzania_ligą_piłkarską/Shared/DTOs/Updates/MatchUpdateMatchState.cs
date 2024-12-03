using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Updates
{
    public class MatchUpdateMatchState
    {
        public int Id { get; set; }
        public bool IsFinished { get; set; }
        public int? Result {  get; set; }
    }
}
