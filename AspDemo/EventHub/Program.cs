var builder = WebApplication.CreateBuilder(args);

var events = new List<Event> {
    new Event(1, "Tech Meetup", "Bangalore", new DateTime(2026, 7, 15)),
    new Event(2, "AI Workshop", "Hyperbad", new DateTime(2026, 9, 18)),
    new Event(3, "Cloud Conference", "Mumbai", new DateTime(2026, 10, 11))
};


builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/events", () => events);

app.Run();


record Event(int Id, string Name, string Location, DateTime Date);





