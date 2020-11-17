using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public AccessRights? AccessRights { get; set; }

        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
