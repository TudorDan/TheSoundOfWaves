using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public interface ICatalogueRepository
    {
        Catalogue GetCatalogue(int id);
        IEnumerable<Catalogue> GetAllCatalogues();
        Catalogue AddCatalogue(Catalogue catalogue);
        Student AddCatalogueStudent(int studentId, int catalogueId, School school);
        Mentor AddCatalogueMentor(int mentorId, int catalogueId, School school);
        Course AddCatalogueCourse(int courseId, int catalogueId, School school);
        Grade AddCatalogueGrade(Grade grade, int catalogueId);
    }
}
