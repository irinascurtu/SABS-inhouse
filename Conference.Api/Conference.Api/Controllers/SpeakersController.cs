using AutoMapper;
using Conference.Api.Models.Speakers;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly ISpeakerService speakerService;
        private readonly IMapper mapper;

        public SpeakersController(ISpeakerService speakerService, IMapper mapper)
        {
            this.speakerService = speakerService;
            this.mapper = mapper;
        }

        [HttpHead("{speakerId}", Name = "CheckSpeaker")]
        public IActionResult CheckIfSpeakerExists(int speakerId)
        {
            var speakerExists = speakerService.SpeakerExists(speakerId);
            if (!speakerExists)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{speakerId}")]
        public ActionResult DeleteSpeaker(int speakerId)
        {
            Speaker speaker = speakerService.GetSpeaker(speakerId);
            if (speaker == null)
            {
                return NotFound();
            }
            var deleted = speakerService.DeleteSpeaker(speaker);
            if (deleted)
            {
                return NoContent();
            }

            return NoContent();
        }

        [HttpPut("{speakerId}")]
        public ActionResult UpdateSpeaker(int speakerId, SpeakerForCreate toUpdate)
        {
            if (speakerId != toUpdate.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var speakerToUpdate = speakerService.GetSpeaker(speakerId);
            //if (speakerToUpdate == null)
            //{
            //    return NotFound();
            //}

            var speakerToUpdate = mapper.Map<Speaker>(toUpdate);

            //
            // TryUpdateModelAsync<Speaker>(speakerToUpdate);
            var updated = speakerService.UpdateSpeaker(speakerToUpdate);


            return Ok(speakerToUpdate);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allSpeakers = speakerService.GetSpeakers();

            return Ok(allSpeakers);
        }

        [HttpGet("{speakerId}")]
        public ActionResult<Speaker> GetById(int speakerId)
        {
            var speaker = speakerService.GetSpeaker(speakerId);
            if (speaker == null)
            {
                return NotFound();
            }

            return Ok(speaker);
        }

        [HttpGet("{speakerId}", Name = "trimmed")]
        [Consumes("application/vnd.speaker.v2.trimmed")]
        public ActionResult<SpeakerTrimmed> GetByIdTrimmed(int speakerId)
        {
            var speaker = speakerService.GetSpeaker(speakerId);
            if (speaker == null)
            {
                return NotFound();
            }
            var trimmed = mapper.Map<SpeakerTrimmed>(speaker);
            return Ok(trimmed);
        }


        [HttpGet("{speakerId}", Name = "trimmed")]
        [Consumes("application/vnd.speaker.v1.trimmed")]
        [Produces("application/xml")]
        public ActionResult<SpeakerTrimmed> GetByIdTrimmedV1(int speakerId)
        {
            var speaker = speakerService.GetSpeaker(speakerId);
            if (speaker == null)
            {
                return NotFound();
            }
            var trimmed = mapper.Map<SpeakerTrimmed>(speaker);
            return Ok(new SpeakerTrimmed());
        }
    }
}
