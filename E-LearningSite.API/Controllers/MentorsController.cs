using E_LearningSite.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_LearningSite.API.Controllers
{
    [EnableCors("ReactApp")]
    [ApiController]
    [Route("api/schools/{schoolId}/[controller]")]
    public class MentorsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public MentorsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        // Mentors
        [HttpGet]
        public IActionResult GetMentors(int schoolId)
        {
            return Ok(_schoolRepository.GetAllMentors(schoolId));
        }

        [HttpGet("{mentorId}", Name = "GetMentor")]
        public IActionResult GetMentor(int schoolId, int mentorId)
        {
            Mentor mentor = _schoolRepository.GetMentor(mentorId, schoolId);
            if (mentor == null)
            {
                return NotFound();
            }
            return Ok(mentor);
        }

        [HttpPost]
        public IActionResult CreateMentor(int schoolId, [FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mentor mentor = new Mentor()
            {
                Name = personDTO.Name,
                Photo = personDTO.Photo,
                BirthDate = personDTO.BirthDate,
                AccessRights = personDTO.AccessRights
            };
            _schoolRepository.AddMentor(mentor, schoolId);
            return CreatedAtRoute("GetMentor", new { schoolId, mentorId = mentor.Id }, mentor);
        }

        [HttpPut("{mentorId}")]
        public IActionResult UpdateMentor(int schoolId, [FromBody] PersonDTO personDTO, int mentorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mentor mentor = _schoolRepository.GetMentor(mentorId, schoolId);
            if (mentor == null)
            {
                return NotFound();
            }
            _schoolRepository.UpdateMentor(mentor, personDTO);
            return NoContent();
        }

        [HttpDelete("{mentorId}")]
        public IActionResult DeleteMentor(int schoolId, int mentorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mentor mentor = _schoolRepository.GetMentor(mentorId, schoolId);
            if (mentor == null)
            {
                return NotFound();
            }
            _schoolRepository.GetAllMentors(schoolId).Remove(mentor);
            _schoolRepository.GetSchool(schoolId).Catalogues.ForEach(c => c.Mentors.Remove(mentor));
            return NoContent();
        }
    }
}
