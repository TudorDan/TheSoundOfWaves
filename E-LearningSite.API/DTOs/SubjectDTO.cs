using E_LearningSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public class SubjectDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
   
        //public List<Course> Courses { get; set; }
        //public School School { get; set; }
        //public int SchoolId { get; set; }




        public SubjectType SubjectType { get; set; }
    }
}
