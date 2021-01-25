using System.Collections.Generic;
using System.Linq;
using E_LearningSite.API.Models;
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
        [HttpGet]
        public IActionResult GetCourses(int schoolId)
        {
            return Ok(_schoolRepository.GetAllCourses(schoolId));
        }

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
            course.Name = courseDTO.Name;
            int subjectId = courseDTO.SubjectId;
            ICollection<Subject> schoolSubjects = _schoolRepository.GetAllSubjects(schoolId);
            Subject subject = schoolSubjects.FirstOrDefault(sbj => sbj.Id == subjectId);
            course.Subject = subject;
            course.Description = courseDTO.Description;
            return NoContent();
        }

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
            _schoolRepository.GetAllCourses(schoolId).Remove(course);
            _schoolRepository.GetSchool(schoolId).Catalogues.ForEach(c => c.Courses.Remove(course));
            return NoContent();
        }

        // Course Documents
        [HttpGet("{courseId}/documents")]
        public IActionResult GetDocuments(int schoolId, int courseId)
        {
            return Ok(_schoolRepository.GetAllDocuments(schoolId, courseId));
        }

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
            document.Name = documentDTO.Name;
            document.Link = documentDTO.Link;
            return NoContent();
        }

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
            _schoolRepository.GetAllDocuments(schoolId, courseId).Remove(document);
            _schoolRepository.GetSchool(schoolId).Catalogues.ForEach(
                c => c.Courses.ForEach(cs => cs.Documents.Remove(document)));
            return NoContent();
        }
    }
}
