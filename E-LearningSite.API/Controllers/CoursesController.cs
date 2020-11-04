using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using E_LearningSite.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningSite.API.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
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
            int maxCourseId = _schoolRepository.GetSchool(schoolId).CoursesList.Max(c => c.Id);
            Course course = new Course()
            {
                Id = ++maxCourseId,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                Description = courseDTO.Description,
                CourseMaterials = courseDTO.CourseMaterials
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
            course.Subject = courseDTO.Subject;
            course.Description = courseDTO.Description;
            course.CourseMaterials = courseDTO.CourseMaterials;
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
            _schoolRepository.GetSchool(schoolId).CataloguesList.ForEach(c => c.ClassCourses.Remove(course));
            return NoContent();
        }

        // Course Materials
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
            int maxDocumentId = _schoolRepository.GetAllDocuments(schoolId, courseId).Max(d => d.Id);
            Document document = new Document()
            {
                Id = ++maxDocumentId,
                Documentation = documentDTO.Documentation,
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
            document.Documentation = documentDTO.Documentation;
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
            _schoolRepository.GetSchool(schoolId).CataloguesList.ForEach(
                c => c.ClassCourses.ForEach(cs => cs.CourseMaterials.Remove(document)));
            return NoContent();
        }
    }
}
