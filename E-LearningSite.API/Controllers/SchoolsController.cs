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

        //// Mentors
        //[HttpGet("{schoolId}/mentors")]
        //public IActionResult GetMentors(int schoolId)
        //{
        //    return Ok(_schoolRepository.GetAllMentors(schoolId));
        //}

        //[HttpGet("{schoolId}/mentors/{mentorId}", Name = "GetMentor")]
        //public IActionResult GetMentor(int schoolId, int mentorId)
        //{
        //    Mentor mentor = _schoolRepository.GetMentor(mentorId, schoolId);
        //    if (mentor == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(mentor);
        //}

        //[HttpPost("{schoolId}/mentors")]
        //public IActionResult CreateMentor(int schoolId, [FromBody] PersonDTO personDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    int maxMentorId = _schoolRepository.GetSchool(schoolId).MentorsList.Max(m => m.Id);
        //    Mentor mentor = new Mentor()
        //    {
        //        Id = ++maxMentorId,
        //        Name = personDTO.Name,
        //        BirthDate = personDTO.BirthDate,
        //        AccessRights = personDTO.AccessRights
        //    };
        //    _schoolRepository.AddMentor(mentor, schoolId);
        //    return CreatedAtRoute("GetMentor", new { schoolId, mentorId = mentor.Id }, mentor);
        //}

        //[HttpPut("{schoolId}/mentors/{mentorId}")]
        //public IActionResult UpdateMentor(int schoolId, [FromBody] PersonDTO personDTO, int mentorId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    Mentor mentor = _schoolRepository.GetMentor(mentorId, schoolId);
        //    if (mentor == null)
        //    {
        //        return NotFound();
        //    }
        //    mentor.Name = personDTO.Name;
        //    mentor.BirthDate = personDTO.BirthDate;
        //    mentor.AccessRights = personDTO.AccessRights;            
        //    return NoContent();
        //}

        //[HttpDelete("{schoolId}/mentors/{mentorId}")]
        //public IActionResult DeleteMentor(int schoolId, int mentorId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    Mentor mentor = _schoolRepository.GetMentor(mentorId, schoolId);
        //    if (mentor == null)
        //    {
        //        return NotFound();
        //    }
        //    _schoolRepository.GetAllMentors(schoolId).Remove(mentor);
        //    _schoolRepository.GetSchool(schoolId).CataloguesList.ForEach(c => c.ClassMentors.Remove(mentor));
        //    return NoContent();
        //}

        // Students
        [HttpGet("{schoolId}/students")]
        public IActionResult GetStudents(int schoolId)
        {
            return Ok(_schoolRepository.GetAllStudents(schoolId));
        }

        [HttpGet("{schoolId}/students/{studentId}", Name = "GetStudent")]
        public IActionResult GetStudent(int schoolId, int studentId)
        {
            Student student = _schoolRepository.GetStudent(studentId, schoolId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("{schoolId}/students")]
        public IActionResult CreateStudent(int schoolId, [FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int maxStudentId = _schoolRepository.GetSchool(schoolId).StudentsList.Max(s => s.Id);
            Student student = new Student()
            {
                Id = ++maxStudentId,
                Name = personDTO.Name,
                BirthDate = personDTO.BirthDate,
                AccessRights = personDTO.AccessRights
            };
            _schoolRepository.AddStudent(student, schoolId);
            return CreatedAtRoute("GetStudent", new { schoolId, studentId = student.Id }, student);
        }

        [HttpPut("{schoolId}/students/{studentId}")]
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
            student.Name = personDTO.Name;
            student.BirthDate = personDTO.BirthDate;
            student.AccessRights = personDTO.AccessRights;
            return NoContent();
        }

        [HttpDelete("{schoolId}/students/{studentId}")]
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
            _schoolRepository.GetSchool(schoolId).CataloguesList.ForEach(c => c.ClassStudents.Remove(student));
            return NoContent();
        }

        // Courses
        [HttpGet("{schoolId}/courses")]
        public IActionResult GetCourses(int schoolId)
        {
            return Ok(_schoolRepository.GetAllCourses(schoolId));
        }

        [HttpGet("{schoolId}/courses/{courseId}", Name = "GetCourse")]
        public IActionResult GetCourse(int schoolId, int courseId)
        {
            Course course = _schoolRepository.GetCourse(courseId, schoolId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost("{schoolId}/courses")]
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

        [HttpPut("{schoolId}/courses/{courseId}")]
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

        [HttpDelete("{schoolId}/courses/{courseId}")]
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
        [HttpGet("{schoolId}/courses/{courseId}/documents")]
        public IActionResult GetDocuments(int schoolId, int courseId)
        {
            return Ok(_schoolRepository.GetAllDocuments(schoolId, courseId));
        }

        [HttpGet("{schoolId}/courses/{courseId}/documents/{documentId}", Name = "GetDocument")]
        public IActionResult GetDocument(int schoolId, int courseId, int documentId)
        {
            Document document = _schoolRepository.GetDocument(documentId, schoolId, courseId);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPost("{schoolId}/courses/{courseId}/documents/")]
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

        [HttpPut("{schoolId}/courses/{courseId}/documents/{documentId}")]
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

        [HttpDelete("{schoolId}/courses/{courseId}/documents/{documentId}")]
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

        // Catalogues
        [HttpGet("{schoolId}/catalogues")]
        public IActionResult GetCatalogues(int schoolId)
        {
            return Ok(_schoolRepository.GetAllCatalogues(schoolId));
        }

        [HttpGet("{schoolId}/catalogues/{catalogueId}", Name = "GetCatalogue")]
        public IActionResult GetCatalogue(int schoolId, int catalogueId)
        {
            Catalogue catalogue = _schoolRepository.GetCatalogue(catalogueId, schoolId);
            if (catalogue == null)
            {
                return NotFound();
            }
            return Ok(catalogue);
        }

        [HttpPost("{schoolId}/catalogues")]
        public IActionResult CreateCatalogue(int schoolId, [FromBody] CatalogueDTO catalogueDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int maxCatalogueId = _schoolRepository.GetSchool(schoolId).CataloguesList.Max(c => c.Id);
            Catalogue catalogue = new Catalogue()
            {
                Id = ++maxCatalogueId,
                ClassName = catalogueDTO.ClassName,
                ClassMentors = catalogueDTO.ClassMentors,
                ClassStudents = catalogueDTO.ClassStudents,
                ClassCourses = catalogueDTO.ClassCourses,
                ClassGrades = catalogueDTO.ClassGrades
            };
            _schoolRepository.AddCatalogue(catalogue, schoolId);
            return CreatedAtRoute("GetCatalogue", new { schoolId, catalogueId = catalogue.Id }, catalogue);
        }

        [HttpPut("{schoolId}/catalogues/{catalogueId}")]
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

        [HttpDelete("{schoolId}/catalogues/{catalogueId}")]
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
        [HttpGet("{schoolId}/catalogues/{catalogueId}/mentors")]
        public IActionResult GetCatalogueMentors(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetALLCatalogueMentors(schoolId, catalogueId));
        }

        [HttpGet("{schoolId}/catalogues/{catalogueId}/mentors/{mentorId}", Name = "GetCatalogueMentor")]
        public IActionResult GetCatalogueMentor(int schoolId, int catalogueId, int mentorId)
        {
            Mentor mentor = _schoolRepository.GetCatalogueMentor(mentorId, schoolId, catalogueId);
            if (mentor == null)
            {
                return NotFound();
            }
            return Ok(mentor);
        }

        [HttpPost("{schoolId}/catalogues/{catalogueId}/mentors")]
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

        [HttpDelete("{schoolId}/catalogues/{catalogueId}/mentors/{mentorId}")]
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
        [HttpGet("{schoolId}/catalogues/{catalogueId}/students")]
        public IActionResult GetCatalogueStudents(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueStudents(schoolId, catalogueId));
        }

        [HttpGet("{schoolId}/catalogues/{catalogueId}/students/{studentId}", Name = "GetCatalogueStudent")]
        public IActionResult GetCatalogueStudent(int schoolId, int catalogueId, int studentId)
        {
            Student student = _schoolRepository.GetCatalogueStudent(studentId, schoolId, catalogueId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("{schoolId}/catalogues/{catalogueId}/students")]
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

        [HttpDelete("{schoolId}/catalogues/{catalogueId}/students/{studentId}")]
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
        [HttpGet("{schoolId}/catalogues/{catalogueId}/courses")]
        public IActionResult GetCatalogueCourses(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueCourses(schoolId, catalogueId));
        }

        [HttpGet("{schoolId}/catalogues/{catalogueId}/courses/{courseId}", Name = "GetCatalogueCourse")]
        public IActionResult GetCatalogueCourse(int schoolId, int catalogueId, int courseId)
        {
            Course course = _schoolRepository.GetCatalogueCourse(courseId, schoolId, catalogueId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost("{schoolId}/catalogues/{catalogueId}/courses")]
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

        [HttpDelete("{schoolId}/catalogues/{catalogueId}/courses/{courseId}")]
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
        [HttpGet("{schoolId}/catalogues/{catalogueId}/grades")]
        public IActionResult GetCatalogueGrades(int schoolId, int catalogueId)
        {
            return Ok(_schoolRepository.GetAllCatalogueGrades(schoolId, catalogueId));
        }

        [HttpGet("{schoolId}/catalogues/{catalogueId}/grades/{gradeId}", Name = "GetCatalogueGrade")]
        public IActionResult GetCatalogueGrade(int schoolId, int catalogueId, int gradeId)
        {
            Grade grade = _schoolRepository.GetCatalogueGrade(gradeId, schoolId, catalogueId);
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }

        [HttpPost("{schoolId}/catalogues/{catalogueId}/grades")]
        public IActionResult CreateCatalogueGrade(int schoolId, int catalogueId, [FromBody] GradeDTO gradeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int maxGradeId;
            try
            {
                maxGradeId = _schoolRepository.GetAllCatalogueGrades(schoolId, catalogueId).Max(g => g.Id);
            }
            catch (InvalidOperationException e)
            {
                maxGradeId = 0;
                Console.WriteLine("{0} Exception caught.", e);
            }
            Grade grade = new Grade()
            {
                Id = ++maxGradeId,
                Student = gradeDTO.Student,
                Mark = gradeDTO.Mark,
                Course = gradeDTO.Course,
                Mentor = gradeDTO.Mentor
            };
            _schoolRepository.AddCatalogueGrade(grade, schoolId, catalogueId);
            return CreatedAtRoute("GetCatalogueGrade", 
                new { schoolId, catalogueId, gradeId = grade.Id }, grade);
        }

        [HttpPut("{schoolId}/catalogues/{catalogueId}/grades/{gradeId}")]
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

        [HttpDelete("{schoolId}/catalogues/{catalogueId}/grades/{gradeId}")]
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
