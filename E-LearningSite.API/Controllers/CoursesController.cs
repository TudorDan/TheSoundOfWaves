using System.Collections.Generic;
using System.Linq;
using E_LearningSite.API.Models;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningSite.API.Controllers
{
    [EnableCors("ReactApp")]
    [ApiController]
    [Route("api/schools/{schoolId}/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public CoursesController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        // Courses
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult GetCourses(int schoolId)
        {
            return Ok(_schoolRepository.GetAllCourses(schoolId));
        }

        //[AllowAnonymous]
        [HttpGet("{courseId}", Name = "GetCourse")]
        public IActionResult GetCourse(int schoolId, int courseId)
        {
            Course course = _schoolRepository.GetCourse(courseId, schoolId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        //[Authorize(Roles = ("Admin, Principle"))]
        [HttpPost]
        public IActionResult CreateCourse(int schoolId, [FromBody] CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int subjectId = courseDTO.SubjectId;
            ICollection<Subject> schoolSubjects = _schoolRepository.GetAllSubjects(schoolId);
            Subject subject = schoolSubjects.FirstOrDefault(sbj => sbj.Id == subjectId);
            Course course = new Course()
            {
                Name = courseDTO.Name,
                Subject = subject,
                Description = courseDTO.Description,
                Documents = courseDTO.Documents
            };
            _schoolRepository.AddCourse(course, schoolId);
            return CreatedAtRoute("GetCourse", new { schoolId, courseId = course.Id }, course);
        }

        //[Authorize(Roles = ("Admin, Principle"))]
        [HttpPut("{courseId}")]
        public IActionResult UpdateCourse(int schoolId, [FromBody] CourseDTO courseDTO, int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Course course = _schoolRepository.GetCourse(courseId, schoolId);
            if (course == null)
            {
                return NotFound();
            }
            _schoolRepository.UpdateCourse(course, courseDTO, courseId);            
            return NoContent();
        }

        //[Authorize(Roles = ("Admin, Principle"))]
        [HttpDelete("{courseId}")]
        public IActionResult DeleteCourse(int schoolId, int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Course course = _schoolRepository.GetCourse(courseId, schoolId);
            if (course == null)
            {
                return NotFound();
            }
            _schoolRepository.DeleteCourse(course, schoolId);
            return NoContent();
        }

        // Course Documents
        //[AllowAnonymous]
        [HttpGet("{courseId}/documents")]
        public IActionResult GetDocuments(int schoolId, int courseId)
        {
            return Ok(_schoolRepository.GetAllDocuments(schoolId, courseId));
        }

        //[AllowAnonymous]
        [HttpGet("{courseId}/documents/{documentId}", Name = "GetDocument")]
        public IActionResult GetDocument(int schoolId, int courseId, int documentId)
        {
            Document document = _schoolRepository.GetDocument(documentId, schoolId, courseId);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        //[Authorize(Roles = ("Admin, Mentor"))]
        [HttpPost("{courseId}/documents")]
        public IActionResult CreateDocument(int schoolId, int courseId,
            [FromBody] DocumentDTO documentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Document document = new Document()
            {
                Name = documentDTO.Name,
                Link = documentDTO.Link
            };
            _schoolRepository.AddDocument(document, schoolId, courseId);
            return CreatedAtRoute("GetDocument", new { schoolId, courseId, documentId = document.Id }, document);
        }

        //[Authorize(Roles = ("Admin, Mentor"))]
        [HttpPut("{courseId}/documents/{documentId}")]
        public IActionResult UpdateDocument(int schoolId, int courseId, int documentId,
            [FromBody] DocumentDTO documentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Document document = _schoolRepository.GetDocument(documentId, schoolId, courseId);
            if (document == null)
            {
                return NotFound();
            }
            _schoolRepository.UpdateDocument(document, documentDTO);
            return NoContent();
        }

        //[Authorize(Roles = ("Admin, Mentor"))]
        [HttpDelete("{courseId}/documents/{documentId}")]
        public IActionResult DeleteDocument(int schoolId, int courseId, int documentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Document document = _schoolRepository.GetDocument(documentId, schoolId, courseId);
            if (document == null)
            {
                return NotFound();
            }
            _schoolRepository.DeleteDocument(document, schoolId, courseId);
            return NoContent();
        }
    }
}
