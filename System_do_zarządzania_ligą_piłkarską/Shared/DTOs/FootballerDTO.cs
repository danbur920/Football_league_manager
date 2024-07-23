using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.Models
{
    public class FootballerDTO
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }
        public int? ShirtNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string? Position { get; set; }
        public int? Height { get; set; } // [cm]
        public int? Weight { get; set; } // [kg]
        public virtual TeamDTO? Team { get; set; }
        public virtual ICollection<FootballerStatDTO> FootballlerStats { get; set; } = new List<FootballerStatDTO>();
        public virtual ICollection<TrophyDTO> Trophies { get; set; } = new List<TrophyDTO>();
    }
}
