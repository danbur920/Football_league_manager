namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public FavouriteType FavouriteType { get; set; }
        public int FavouriteId { get; set; }
        public virtual ApplicationUser? User { get; set; }
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
