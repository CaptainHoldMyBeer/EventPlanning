using Infrastructure.Bll.Core.EventProviderService;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DtoModels;
using System;
using System.Threading.Tasks;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventProvider _eventProvider;
        private readonly ApplicationContext _context;
        public EventController(IEventProvider eventProvider, ApplicationContext context)
        {
            _eventProvider = eventProvider;
            _context = context;
        }
        [Route("createEvent")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventDto newEvent)
        {
            try
            {
                var result = await _eventProvider.CreateEvent(newEvent);

                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("bad event data");
            }
            catch (Exception)
            {
                return StatusCode(500, "error on creating event");
            }
        }

        [Route("getAllEvents")]
        [HttpGet]
        public IActionResult GetAllEvents(int userId)
        {
            try
            {
                var result = _eventProvider.GetAllEvents(userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "error on getting all events");
            }
        }

        [Route("getEventsForUser")]
        [HttpGet]
        public IActionResult GetEventsForUser(int userId)
        {
            try
            {
                var result = _eventProvider.GetAllEventsByUserId(userId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "error on getting events");
            }
        }

        [Route("joinEvent")]
        [HttpGet]
        public IActionResult JoinEvent(int userId, int eventId)
        {
            try
            {
                var result = _eventProvider.JoinEvent(userId, eventId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "error on joining event");
            }
        }

    }
}
