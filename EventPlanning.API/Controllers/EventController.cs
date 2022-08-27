using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Bll.Core.EventProviderService;
using Model;
using Model.DtoModels;
using NPOI.OpenXmlFormats.Wordprocessing;

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
        public async Task<bool> CreateEvent(EventDto newEvent)
        {
            try
            {
                return await _eventProvider.CreateEvent(newEvent);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding new Event");
            }
        }

        [Route("getAllEvents")]
        [HttpGet]
        public async Task<List<EventDto>> GetAllEvents()
        {
            try
            {
                var tmp = _context.Events.ToList();
                var t = _context.EventUsers.ToList();
                return await _eventProvider.GetAllEvents();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding new Event");
            }
        }

    }
}
