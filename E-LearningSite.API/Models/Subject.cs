using E_LearningSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public class Subject
    {
        public int Id { get; set; }
        public SubjectType SubjectType { get; set; }
        public string SubjectName { 
            get {
                return Enum.GetName(typeof(SubjectType), SubjectType);
            }
            set {
                SubjectName = Enum.GetName(typeof(SubjectType), SubjectType);
            }
        }

    }
}
