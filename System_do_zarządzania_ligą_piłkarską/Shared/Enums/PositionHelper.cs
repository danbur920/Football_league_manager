using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.Enums
{
    public enum Position
    {
        [Display(Name = "Bramkarz")]
        Goalkeeper,
        [Display(Name = "Obrońca")]
        Defender,
        [Display(Name = "Pomocnik")]
        Midfielder,
        [Display(Name = "Napastnik")]
        Forward
    }
    public static class PositionHelper
    {
        public static string GetDisplayName(Position position)
        {
            return position switch
            {
                Position.Goalkeeper => "Bramkarz",
                Position.Defender => "Obrońca",
                Position.Midfielder => "Pomocnik",
                Position.Forward => "Napastnik",
                _ => position.ToString()
            };
        }

        public static List<Position> GetAllPositions()
        {
            return Enum.GetValues(typeof(Position)).Cast<Position>().ToList();
        }
    }
}
