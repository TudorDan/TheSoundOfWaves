using E_LearningSite.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web.Http.Cors;

namespace E_LearningSite.API.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpGet]
        public IActionResult GetSchools()
        {
            return Ok(_schoolRepository.GetAllSchools());
        }

        [HttpGet("{schoolId}", Name = "GetSchool")]
        public IActionResult GetSchool(int schoolId)
        {
            School schoolToReturn = _schoolRepository.GetSchool(schoolId);
            if (schoolToReturn == null)
            {
                return NotFound();
            }
            return Ok(schoolToReturn);
        }

        [HttpPost]
        public IActionResult CreateSchool([FromBody] SchoolDTO schoolDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int maxSchoolId = _schoolRepository.GetAllSchools().Max(s => s.Id);
            School school = new School()
            {
                Id = ++maxSchoolId,
                Name = schoolDTO.Name,
                Principal = schoolDTO.Principal,
                MentorsList = schoolDTO.MentorsList,
                StudentsList = schoolDTO.StudentsList,
                CoursesList = schoolDTO.CoursesList,
                CataloguesList = schoolDTO.CataloguesList
            };
            _schoolRepository.AddSchool(school);
            return CreatedAtRoute("GetSchool", new { schoolId = school.Id }, school);
        }

        [HttpPut("{schoolId}")]
        public IActionResult UpdateSchool(int schoolId, [FromBody] SchoolDTO schoolDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            School school = _schoolRepository.GetSchool(schoolId);
            if (school == null)
            {
                return NotFound();
            }
            school.Name = schoolDTO.Name;
            school.Principal = schoolDTO.Principal;
            school.MentorsList = schoolDTO.MentorsList;
            school.StudentsList = schoolDTO.StudentsList;
            school.CoursesList = schoolDTO.CoursesList;
            school.CataloguesList = schoolDTO.CataloguesList;
            return NoContent();
        }

        [HttpDelete("{schoolId}")]
        public IActionResult DeleteSchool(int schoolId)
        {
            School school = _schoolRepository.GetSchool(schoolId);
            if (school == null)
            {
                return NotFound();
            }
            _schoolRepository.GetAllSchools().Remove(school);
            return NoContent();
        }            

    }
}
