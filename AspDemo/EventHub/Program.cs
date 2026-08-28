using EventHub.Models;
using EventHub.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EventService>();



builder.Services.AddOpenApi();

var app = builder.Build();

app.Use(async(context, next) =>{
    Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Response sent: {context.Response.StatusCode}");

});

// app.MapGet("/events", () => events);
app.MapGet("/events", (EventService eventService) => eventService.GetAllEvents());

app.Run();








