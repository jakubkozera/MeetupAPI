using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetupAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Controllers
{
    [Route("api/meetup")]
    public class MeetupController : ControllerBase
    {
        private readonly MeetupContext _meetupContext;

        public MeetupController(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
        }

        [HttpGet]
        public ActionResult<List<Meetup>> Get()
        {
            var meetups = _meetupContext.Meetups.ToList();

            return Ok(meetups);
        }
    }
}
