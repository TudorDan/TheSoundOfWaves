using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Document
    {
        public int Id { get; set; }
        public string Documentation { get; set; }
        public string Link { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
