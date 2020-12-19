using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class CourseCatalogue
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }

        public Catalogue Catalogue { get; set; }
        public int CatalogueId { get; set; }
    }
}
