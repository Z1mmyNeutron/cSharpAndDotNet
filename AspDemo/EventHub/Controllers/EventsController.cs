using EventHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Controllers;

[ApiController]
[Route(
    "api/[controller]"
)]
public class EventsController : ControllerBase{
    private readonly EventService _eventService;
    public EventsController(EventService eventService){
        _eventService = eventService;
    }
    [HttpGet]
    public IActionResult GetAll(){
        return Ok(_eventService.GetAllEvents());
        }
}