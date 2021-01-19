using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class SchoolSubject
    {
        public School school { get; set; }
        public int SchoolId { get; set; }

        public Subject subject { get; set; }
        public int SubjectId { get; set; }
    }
}
