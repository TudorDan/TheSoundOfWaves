using System.Linq;
using E_LearningSite.API.Models;
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
        [HttpGet]
        public IActionResult GetStudents(int schoolId)
        {
            return Ok(_schoolRepository.GetAllStudents(schoolId));
        }

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
            _schoolRepository.GetAllStudents(schoolId).Remove(student);
            _schoolRepository.GetSchool(schoolId).Catalogues.ForEach(c => c.Students.Remove(student));
            return NoContent();
        }
    }
}
