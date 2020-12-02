using E_LearningSite.API.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_LearningSite.API.Controllers
{
    [EnableCors("ReactApp")]
    [ApiController]
    [Route("api/schools/{schoolId}/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public SubjectsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        // Subjects
        [HttpGet]
        public IActionResult GetSubjects(int schoolId)
        {
            return Ok(_schoolRepository.GetAllSubjects(schoolId));
        }

        [HttpGet("{subjectId}", Name = "GetSubject")]
        public IActionResult GetSubject(int schoolId, int subjectId)
        {
            Subject subject = _schoolRepository.GetSubject(subjectId, schoolId);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public IActionResult CreateSubject(int schoolId, [FromBody] SubjectDTO subjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Subject subject= new Subject()
            {
                SubjectType = subjectDTO.SubjectType,
            };
            _schoolRepository.AddSubject(subject, schoolId);
            return CreatedAtRoute("GetSubject", new { schoolId, subjectId = subject.Id }, subject);
        }

        [HttpPut("{subjectId}")]
        public IActionResult UpdateSubject(int schoolId, [FromBody] SubjectDTO subjectDTO, int subjectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Subject subject = _schoolRepository.GetSubject(subjectId, schoolId);
            if (subject == null)
            {
                return NotFound();
            }
            subject.SubjectType = subjectDTO.SubjectType;
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public IActionResult DeleteSubject(int schoolId, int subjectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Subject subject = _schoolRepository.GetSubject(subjectId, schoolId);
            if (subject == null)
            {
                return NotFound();
            }
            _schoolRepository.GetAllSubjects(schoolId).Remove(subject);
            // should delete all courses with specific subject
            //_schoolRepository.GetAllCourses(schoolId). .ForEach(c => c.ClassMentors.Remove(mentor));
            return NoContent();
        }
    }
}
