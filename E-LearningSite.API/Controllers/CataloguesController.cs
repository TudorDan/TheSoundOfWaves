﻿using System;
using System.Linq;
using E_LearningSite.API.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningSite.API.Controllers
{
    [EnableCors("ReactApp")]
    [ApiController]
    [Route("api/schools/{schoolId}/[controller]")]
    public class CataloguesController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public CataloguesController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        // Catalogues
        [HttpGet]
        public IActionResult GetCatalogues(int schoolId)
        {
            return Ok(_schoolRepository.GetAllCatalogues(schoolId));
        }

        [HttpGet("{catalogueId}", Name = "GetCatalogue")]
        public IActionResult GetCatalogue(int schoolId, int catalogueId)
        {
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            if (catalogue == null)
            {
                return NotFound();
            }
            return Ok(catalogue);
        }

        [HttpPost]
        public IActionResult CreateCatalogue(int schoolId, [FromBody] CatalogueDTO catalogueDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Catalogue catalogue = new Catalogue()
            {
                ClassName = catalogueDTO.ClassName,
                ClassMentors = catalogueDTO.ClassMentors,
                ClassStudents = catalogueDTO.ClassStudents,
                ClassCourses = catalogueDTO.ClassCourses,
                ClassGrades = catalogueDTO.ClassGrades
            };
            _schoolRepository.AddCatalogue(catalogue, schoolId);
            return CreatedAtRoute("GetCatalogue", new { schoolId, catalogueId = catalogue.Id }, catalogue);
        }

        [HttpPut("{catalogueId}")]
        public IActionResult UpdateCatalogue(int schoolId, [FromBody] CatalogueDTO catalogueDTO, int catalogueId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            if (catalogue == null)
            {
                return NotFound();
            }
            catalogue.ClassName = catalogueDTO.ClassName;
            catalogue.ClassMentors = catalogueDTO.ClassMentors;
            catalogue.ClassStudents = catalogueDTO.ClassStudents;
            catalogue.ClassCourses = catalogueDTO.ClassCourses;
            catalogue.ClassGrades = catalogueDTO.ClassGrades;
            return NoContent();
        }

        [HttpDelete("{catalogueId}")]
        public IActionResult DeleteCatalogue(int schoolId, int catalogueId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            if (catalogue == null)
            {
                return NotFound();
            }
            _schoolRepository.GetAllCatalogues(schoolId).Remove(catalogue);
            return NoContent();
        }

        // Catalogue Mentors
        [HttpGet("{catalogueId}/mentors")]
        public IActionResult GetCatalogueMentors(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetALLCatalogueMentors(schoolId, catalogueId));
        }

        [HttpGet("{catalogueId}/mentors/{mentorId}", Name = "GetCatalogueMentor")]
        public IActionResult GetCatalogueMentor(int schoolId, int catalogueId, int mentorId)
        {
            Mentor mentor = _schoolRepository.GetCatalogueMentor(mentorId, schoolId, catalogueId);
            if (mentor == null)
            {
                return NotFound();
            }
            return Ok(mentor);
        }

        [HttpPost("{catalogueId}/mentors")]
        public IActionResult CreateCatalogueMentor(int schoolId, int catalogueId, [FromBody] int mentorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mentor mentor = _schoolRepository.GetMentor(mentorId, schoolId);
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            catalogue.ClassMentors.Add(mentor);
            return CreatedAtRoute("GetCatalogueMentor", new { schoolId, catalogueId, mentorId }, mentor);
        }

        [HttpDelete("{catalogueId}/mentors/{mentorId}")]
        public IActionResult DeleteCatalogueMentor(int schoolId, int catalogueId, int mentorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mentor mentor = _schoolRepository.GetCatalogueMentor(mentorId, schoolId, catalogueId);
            if (mentor == null)
            {
                return NotFound();
            }
            _schoolRepository.GetCatalogue(catalogueId, schoolId).ClassMentors.Remove(mentor);
            return NoContent();
        }

        // Catalogue Students
        [HttpGet("{catalogueId}/students")]
        public IActionResult GetCatalogueStudents(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueStudents(schoolId, catalogueId));
        }

        [HttpGet("{catalogueId}/students/{studentId}", Name = "GetCatalogueStudent")]
        public IActionResult GetCatalogueStudent(int schoolId, int catalogueId, int studentId)
        {
            Student student = _schoolRepository.GetCatalogueStudent(studentId, schoolId, catalogueId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("{catalogueId}/students")]
        public IActionResult CreateCatalogueStudent(int schoolId, int catalogueId, [FromBody] int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student student = _schoolRepository.GetStudent(studentId, schoolId);
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            catalogue.ClassStudents.Add(student);
            return CreatedAtRoute("GetCatalogueStudent", new { schoolId, catalogueId, studentId }, student);
        }

        [HttpDelete("{catalogueId}/students/{studentId}")]
        public IActionResult DeleteCatalogueStudent(int schoolId, int catalogueId, int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student student = _schoolRepository.GetCatalogueStudent(studentId, schoolId, catalogueId);
            if (student == null)
            {
                return NotFound();
            }
            _schoolRepository.GetCatalogue(catalogueId, schoolId).ClassStudents.Remove(student);
            return NoContent();
        }

        // Catalogue Courses
        [HttpGet("{catalogueId}/courses")]
        public IActionResult GetCatalogueCourses(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueCourses(schoolId, catalogueId));
        }

        [HttpGet("{catalogueId}/courses/{courseId}", Name = "GetCatalogueCourse")]
        public IActionResult GetCatalogueCourse(int schoolId, int catalogueId, int courseId)
        {
            Course course = _schoolRepository.GetCatalogueCourse(courseId, schoolId, catalogueId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost("{catalogueId}/courses")]
        public IActionResult CreateCatalogueCourse(int schoolId, int catalogueId, [FromBody] int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Course course = _schoolRepository.GetCourse(courseId, schoolId);
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            catalogue.ClassCourses.Add(course);
            return CreatedAtRoute("GetCatalogueCourse", new { schoolId, catalogueId, courseId }, course);
        }

        [HttpDelete("{catalogueId}/courses/{courseId}")]
        public IActionResult DeleteCatalogueCourse(int schoolId, int catalogueId, int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Course course = _schoolRepository.GetCatalogueCourse(courseId, schoolId, catalogueId);
            if (course == null)
            {
                return NotFound();
            }
            _schoolRepository.GetAllCatalogueCourses(schoolId, catalogueId).Remove(course);
            return NoContent();
        }

        // Catalogue Grades
        [HttpGet("{catalogueId}/grades")]
        public IActionResult GetCatalogueGrades(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueGrades(schoolId, catalogueId));
        }

        [HttpGet("{catalogueId}/grades/{gradeId}", Name = "GetCatalogueGrade")]
        public IActionResult GetCatalogueGrade(int schoolId, int catalogueId, int gradeId)
        {
            Grade grade = _schoolRepository.GetCatalogueGrade(gradeId, schoolId, catalogueId);
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }

        [HttpPost("{catalogueId}/grades")]
        public IActionResult CreateCatalogueGrade(int schoolId, int catalogueId, [FromBody] GradeDTO gradeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Grade grade = new Grade()
            {
                Student = gradeDTO.Student,
                Mark = gradeDTO.Mark,
                Course = gradeDTO.Course,
                Mentor = gradeDTO.Mentor
            };
            _schoolRepository.AddCatalogueGrade(grade, schoolId, catalogueId);
            return CreatedAtRoute("GetCatalogueGrade",
                new { schoolId, catalogueId, gradeId = grade.Id }, grade);
        }

        [HttpPut("{catalogueId}/grades/{gradeId}")]
        public IActionResult UpdateCatalogueGrade(int schoolId, int catalogueId, int gradeId,
            [FromBody] GradeDTO gradeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Grade grade = _schoolRepository.GetCatalogueGrade(gradeId, schoolId, catalogueId);
            if (grade == null)
            {
                return NotFound();
            }
            grade.Student = gradeDTO.Student;
            grade.Mark = gradeDTO.Mark;
            grade.Course = gradeDTO.Course;
            grade.Mentor = gradeDTO.Mentor;
            return NoContent();
        }

        [HttpDelete("{catalogueId}/grades/{gradeId}")]
        public IActionResult DeleteCatalogueGrade(int schoolId, int catalogueId, int gradeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Grade grade = _schoolRepository.GetCatalogueGrade(gradeId, schoolId, catalogueId);
            if (grade == null)
            {
                return NotFound();
            }
            _schoolRepository.GetAllCatalogueGrades(schoolId, catalogueId).Remove(grade);
            return NoContent();
        }
    }
}