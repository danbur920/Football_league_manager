using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Shared.Enums
{
    public enum EventType
    {
        Goal,
        OwnGoal,
        YellowCard,
        RedCard,
        Penalty,
        MissedPenalty,
        Substitution
    }
    public static class EventTypeHelper
    {
        public static string GetDisplayName(EventType eventType)
        {
            return eventType switch
            {
                EventType.Goal => "Gol",
                EventType.OwnGoal => "Gol samobójczy",
                EventType.YellowCard => "Żółta kartka",
                EventType.RedCard => "Czerwona kartka",
                EventType.Penalty => "Rzut karny - gol",
                EventType.MissedPenalty => "Rzut karny - nietrafiony",
                EventType.Substitution => "Zmiana",
                _ => eventType.ToString()
            };
        }

        public static List<EventType> GetAllEventTypes()
        {
            return Enum.GetValues(typeof(EventType)).Cast<EventType>().ToList();
        }
    }
}
