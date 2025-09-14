using AICalendar.Domain;

namespace AICalendar.Data
{
    public class EventRepository : IEventService
    {
        public string GetWelcome()
        {
            return "Welcome from Data Layer!";
        }
    }
}

