﻿using System;
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
    public class CataloguesController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public CataloguesController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        // Catalogues
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult GetCatalogues(int schoolId)
        {
            return Ok(_schoolRepository.GetAllCatalogues(schoolId));
        }

        //[AllowAnonymous]
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

        //[Authorize(Roles = ("Admin, Principle"))]
        [HttpPost]
        public IActionResult CreateCatalogue(int schoolId, [FromBody] CatalogueDTO catalogueDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Catalogue catalogue = new Catalogue()
            {
                Name = catalogueDTO.Name,
                Mentors = catalogueDTO.Mentors,
                Students = catalogueDTO.Students,
                Courses = catalogueDTO.Courses,
                Grades = catalogueDTO.Grades
            };
            _schoolRepository.AddCatalogue(catalogue, schoolId);
            return CreatedAtRoute("GetCatalogue", new { schoolId, catalogueId = catalogue.Id }, catalogue);
        }

        //[Authorize(Roles = ("Admin, Principle"))]
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
            _schoolRepository.UpdateCatalogue(catalogue, catalogueDTO);
            return NoContent();
        }

        //[Authorize(Roles = ("Admin, Principle"))]
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
            _schoolRepository.DeleteCatalogue(catalogue, schoolId);
            return NoContent();
        }

        // Catalogue Mentors

        //[AllowAnonymous]
        [HttpGet("{catalogueId}/mentors")]
        public IActionResult GetCatalogueMentors(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetALLCatalogueMentors(schoolId, catalogueId));
        }

        //[AllowAnonymous]
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

        //[Authorize(Roles ="Admin, Principle")]
        [HttpPost("{catalogueId}/mentors")]
        public IActionResult CreateCatalogueMentor(int schoolId, int catalogueId, [FromBody] CataloguePersonDTO cataloguePersonDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Mentor mentor = _schoolRepository.GetMentor(cataloguePersonDTO.Id, schoolId);
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            foreach (Mentor ment in catalogue.Mentors)
            {
                if (ment.Id == mentor.Id)
                {
                    return Conflict(mentor.Name);
                }
            }
            _schoolRepository.AddCatalogueMentor(mentor, schoolId, catalogueId);
            return CreatedAtRoute("GetCatalogueMentor", new { schoolId, catalogueId, mentorId = mentor.Id }, mentor);
        }

        //[Authorize(Roles = "Admin, Principle")]
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
            _schoolRepository.DeleteCatalogueMentor(mentor, schoolId, catalogueId);
            return NoContent();
        }

        // Catalogue Students

        //[AllowAnonymous]
        [HttpGet("{catalogueId}/students")]
        public IActionResult GetCatalogueStudents(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueStudents(schoolId, catalogueId));
        }

        //[AllowAnonymous]
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

        //[Authorize(Roles = ("Admin, Mentor"))]
        [HttpPost("{catalogueId}/students")]
        public IActionResult CreateCatalogueStudent(int schoolId, int catalogueId, [FromBody] CataloguePersonDTO cataloguePersonDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student student = _schoolRepository.GetStudent(cataloguePersonDTO.Id, schoolId);
            List<Catalogue> catalogues = (List<Catalogue>)_schoolRepository.GetAllCatalogues(schoolId);
            foreach (Catalogue catalogue in catalogues)
            {
                foreach (Student stud in catalogue.Students)
                {
                    if (stud.Id == student.Id)
                    {
                        return Conflict(student.Name);
                    }
                }
            }            
            _schoolRepository.AddCatalogueStudent(student, schoolId, catalogueId);
            return CreatedAtRoute("GetCatalogueStudent", new { schoolId, catalogueId, studentId = student.Id }, student);
        }

        //[Authorize(Roles = ("Admin, Mentor"))]
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
            _schoolRepository.DeleteCatalogueStudent(student, schoolId, catalogueId);
            return NoContent();
        }

        // Catalogue Courses

        //[AllowAnonymous]
        [HttpGet("{catalogueId}/courses")]
        public IActionResult GetCatalogueCourses(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueCourses(schoolId, catalogueId));
        }

        //[AllowAnonymous]
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

        //[Authorize(Roles = ("Admin, Mentor"))]
        [HttpPost("{catalogueId}/courses")]
        public IActionResult CreateCatalogueCourse(int schoolId, int catalogueId, [FromBody] CataloguePersonDTO cataloguePersonDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Course course = _schoolRepository.GetCourse(cataloguePersonDTO.Id, schoolId);
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            foreach (Course cour in catalogue.Courses)
            {
                if (cour.Id == course.Id)
                {
                    return Conflict(course.Name);
                }
            }
            _schoolRepository.AddCatalogueCourse(course, schoolId, catalogueId);
            return CreatedAtRoute("GetCatalogueCourse", new { schoolId, catalogueId, courseId = course.Id }, course);
        }

        //[Authorize(Roles = ("Admin, Mentor"))]
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
            _schoolRepository.DeleteCatalogueCourse(course, schoolId, catalogueId);
            return NoContent();
        }

        // Catalogue Grades

        //[AllowAnonymous]
        [HttpGet("{catalogueId}/grades")]
        public IActionResult GetCatalogueGrades(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueGrades(schoolId, catalogueId));
        }

        //[AllowAnonymous]
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

        //[Authorize(Roles = ("Admin, Mentor"))]
        [HttpPost("{catalogueId}/grades")]
        public IActionResult CreateCatalogueGrade(int schoolId, int catalogueId, [FromBody] GradeDTO gradeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student student = _schoolRepository.GetStudent(gradeDTO.StudentId, schoolId);
            Course course = _schoolRepository.GetCourse(gradeDTO.CourseId, schoolId);
            Mentor mentor = _schoolRepository.GetMentor(gradeDTO.MentorId, schoolId);
            Grade grade = new Grade()
            {
                Student = student,
                Mark = gradeDTO.Mark,
                Course = course,
                Mentor = mentor,
                Date = gradeDTO.Date
            };
            _schoolRepository.AddCatalogueGrade(grade, schoolId, catalogueId);
            return CreatedAtRoute("GetCatalogueGrade",
                new { schoolId, catalogueId, gradeId = grade.Id }, grade);
        }

        //[Authorize(Roles = ("Admin, Mentor"))]
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
            _schoolRepository.UpdateCatalogueGrade(grade, gradeDTO, schoolId);

            return NoContent();
        }

        //[Authorize(Roles = ("Admin, Mentor"))]
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
            _schoolRepository.DeleteCatalogueGrade(grade, schoolId, catalogueId);
            return NoContent();
        }
    }
}
