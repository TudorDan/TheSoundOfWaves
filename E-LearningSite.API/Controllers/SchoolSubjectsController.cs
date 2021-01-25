using E_LearningSite.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                Name = subjectDTO.Name
            };
            ICollection<Subject> schoolSubjects = _schoolRepository.GetAllSubjects(schoolId);
            foreach (Subject subj in schoolSubjects)
            {
                if (subj.Name == subject.Name)
                {
                    return Conflict(subject.Name);
                }
            }            
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
            _schoolRepository.UpdateSubject(subject, subjectDTO);
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

        // Subjects Types
        /*[HttpGet("types")]
        public IActionResult GetTypes()
        {
            return Ok(_schoolRepository.GetAllSubjects());

            *//*List<EnumValue> subjectTypes = new List<EnumValue>();            
            foreach (var element in Enum.GetValues(typeof(SubjectType))) 
            { 
                subjectTypes.Add(new EnumValue() 
                {
                    Id = (int)element,
                    Name = element.ToString(),
                }); 
            }
            return Ok(subjectTypes);*//*
        }*/
    }
}
