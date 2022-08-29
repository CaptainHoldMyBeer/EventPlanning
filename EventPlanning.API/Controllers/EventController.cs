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
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("getAllEvents")]
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            try
            {
                var result = _eventProvider.GetAllEvents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
