using EventHub.Models;

namespace EventHub.Services;

public class EventService{
    private readonly List<Event> _events = new List<Event> {
    new Event(1, "Tech Meetup", "Bangalore", new DateTime(2026, 7, 15)),
    new Event(2, "AI Workshop", "Hyperbad", new DateTime(2026, 9, 18)),
    new Event(3, "Cloud Conference", "Mumbai", new DateTime(2026, 10, 11))
};
public List<Event> GetAllEvents(){
    return _events;
}


}