using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class CourseCatalogue
    {
        public int CourseId { get; set; }
        public int CatalogueId { get; set; }

        public Course Course { get; set; }
        public Catalogue Catalogue { get; set; }
    }
}
