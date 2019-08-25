using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MeetupAPI.Entities;
using MeetupAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Controllers
{
    [Route("api/meetup")]
    public class MeetupController : ControllerBase
    {
        private readonly MeetupContext _meetupContext;
        private readonly IMapper _mapper;

        public MeetupController(MeetupContext meetupContext, IMapper mapper)
        {
            _meetupContext = meetupContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<MeetupDetailsDto>> Get()
        {
            var meetups = _meetupContext.Meetups.Include(m => m.Location).ToList();
            var meetupDtos = _mapper.Map<List<MeetupDetailsDto>>(meetups);
            return Ok(meetupDtos);
        }

        [HttpGet("{name}")]
        public ActionResult<MeetupDetailsDto> Get(string name)
        {
            var meetup = _meetupContext.Meetups
                .Include(m => m.Location)
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.ToLower());

            if (meetup == null)
            {
                return NotFound();
            }

            var meetupDto = _mapper.Map<MeetupDetailsDto>(meetup);
            return Ok(meetupDto);
        }
    }
}
