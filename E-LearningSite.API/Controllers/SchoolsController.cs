using E_LearningSite.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_LearningSite.API.Controllers
{
    [EnableCors("ReactApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetSchools()
        {
            return Ok(_schoolRepository.GetAllSchools());
        }

        [AllowAnonymous]
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

        [Authorize(Roles = "Admin, Principle")]
        [HttpPost]
        public IActionResult CreateSchool([FromBody] SchoolDTO schoolDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            School school = new School()
            {
                Name = schoolDTO.Name,
                Principal = schoolDTO.Principal,
                Photo = schoolDTO.Photo,
                Mentors = schoolDTO.Mentors,
                Students = schoolDTO.Students,
                Courses = schoolDTO.Courses,
                Catalogues = schoolDTO.Catalogues,
                Subjects = schoolDTO.Subjects
            };
            _schoolRepository.AddSchool(school);
            return CreatedAtRoute("GetSchool", new { schoolId = school.Id }, school);
        }

        [Authorize(Roles = "Admin, Principle")]
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
            _schoolRepository.UpdateSchool(school, schoolDTO);
            return NoContent();
        }

        [Authorize(Roles = "Admin, Principle")]
        [HttpDelete("{schoolId}")]
        public IActionResult DeleteSchool(int schoolId)
        {
            School school = _schoolRepository.GetSchool(schoolId);
            if (school == null)
            {
                return NotFound();
            }
            _schoolRepository.DeleteSchool(school);
            return NoContent();
        }            

    }
}
