using E_LearningSite.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.InMemoryDatabase
{
    public class InMemoryCatalogueDatabase : ICatalogueRepository
    {
        private readonly List<Catalogue> _catalogueDataBase;

        public InMemoryCatalogueDatabase()
        {
            _catalogueDataBase = new List<Catalogue>();
        }

        public Catalogue AddCatalogue(Catalogue catalogue)
        {
            catalogue.Id = _catalogueDataBase.Max(s => s.Id) + 1;
            _catalogueDataBase.Add(catalogue);
            return catalogue;
        }

        public Course AddCatalogueCourse(int courseId, int catalogueId, School school)
        {
            Course course = school.CoursesList.FirstOrDefault(c => c.Id == courseId);

            Catalogue catalogue = _catalogueDataBase.FirstOrDefault(c => c.Id == catalogueId);
            catalogue.ClassCourses.Add(course);
            return course;
        }

        public Grade AddCatalogueGrade(Grade grade, int catalogueId)
        {
            Catalogue catalogue = _catalogueDataBase.FirstOrDefault(c => c.Id == catalogueId);
            grade.Id = catalogue.ClassGrades.Max(g => g.Id) + 1;
            catalogue.ClassGrades.Add(grade);
            return grade;
        }

        public Mentor AddCatalogueMentor(int mentorId, int catalogueId, School school)
        {
            Mentor mentor = school.MentorsList.FirstOrDefault(m => m.Id == mentorId);

            Catalogue catalogue = _catalogueDataBase.FirstOrDefault(c => c.Id == catalogueId);
            catalogue.ClassMentors.Add(mentor);
            return mentor;
        }

        public Student AddCatalogueStudent(int studentId, int catalogueId, School school)
        {
            Student student = school.StudentsList.FirstOrDefault(s => s.Id == studentId);

            Catalogue catalogue = _catalogueDataBase.FirstOrDefault(c => c.Id == catalogueId);
            catalogue.ClassStudents.Add(student);
            return student;
        }

        public IEnumerable<Catalogue> GetAllCatalogues()
        {
            return _catalogueDataBase;
        }

        public Catalogue GetCatalogue(int id)
        {
            return _catalogueDataBase.FirstOrDefault(c => c.Id == id);
        }
    }
}
