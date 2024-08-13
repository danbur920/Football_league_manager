using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class FavouriteDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public FavouriteType FavouriteType { get; set; }
        public int FavouriteId { get; set; }
    }

    public enum FavouriteType
    {
        League,
        Footballer,
        Team,
        Match,
        Referee
    }
}
