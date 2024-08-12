namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? PrimaryFootballerId { get; set; } // strzelec gola,
                                                      // żółta/czerwona kartka,
                                                      // wykonawca rzutu karnego,
                                                      // zawodnik schodzący
        public int? SecondaryFootballerId { get; set; } // asystent gola,
                                                        // zawodnik wchodzący
        public int? TeamId { get; set; }
        public int? Minute {  get; set; }
        public string? Description { get; set; }
        public EventType EventType { get; set; }
        public Match? Match { get; set; }
    }

    public enum EventType
    {
        Goal,
        YellowCard,
        RedCard,
        Penalty,
        Substitution
    }
}

// Info: faule nie będą zdarzeniem meczowym. Ilość fauli będzie można wpisać podczas wpisywania wyniku meczu.