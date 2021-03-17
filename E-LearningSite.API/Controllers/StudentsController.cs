using System.Linq;
using E_LearningSite.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningSite.API.Controllers
{
    [EnableCors("ReactApp")]
    [ApiController]
    [Route("api/schools/{schoolId}/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public StudentsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        // Students
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetStudents(int schoolId)
        {
            return Ok(_schoolRepository.GetAllStudents(schoolId));
        }

        [AllowAnonymous]
        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult GetStudent(int schoolId, int studentId)
        {
            Student student = _schoolRepository.GetStudent(studentId, schoolId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Authorize(Roles = ("Admin, Principle"))]
        [HttpPost]
        public IActionResult CreateStudent(int schoolId, [FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student student = new Student()
            {
                Name = personDTO.Name,
                BirthDate = personDTO.BirthDate,
                Photo = personDTO.Photo,
                AccessRights = personDTO.AccessRights
            };
            _schoolRepository.AddStudent(student, schoolId);
            return CreatedAtRoute("GetStudent", new { schoolId, studentId = student.Id }, student);
        }

        [Authorize(Roles = ("Admin, Principle"))]
        [HttpPut("{studentId}")]
        public IActionResult UpdateStudent(int schoolId, [FromBody] PersonDTO personDTO, int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student student = _schoolRepository.GetStudent(studentId, schoolId);
            if (student == null)
            {
                return NotFound();
            }
            _schoolRepository.UpdateStudent(student, personDTO);
            return NoContent();
        }

        [Authorize(Roles = ("Admin, Principle"))]
        [HttpDelete("{studentId}")]
        public IActionResult DeleteStudent(int schoolId, int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student student = _schoolRepository.GetStudent(studentId, schoolId);
            if (student == null)
            {
                return NotFound();
            }
            _schoolRepository.DeleteStudent(student, schoolId);
            return NoContent();
        }
    }
}
