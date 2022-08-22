using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        [Route("createEvent")]
        [HttpPost]
        public IActionResult CreateEvent()
        {
            return Ok("create");
        }

        [Route("getInfo")]
        [HttpGet]
        public IActionResult GetEventInformation()
        {
            return Ok("get info");
        }

        [Route("getAllEvents")]
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            return Ok("get all");
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult DeleteEvent()
        {
            return Ok("delete");
        }

        [Route("EditEvent")]
        [HttpPut]
        public IActionResult EditEvent()
        {
            return Ok("edit");
        }
    }
}
