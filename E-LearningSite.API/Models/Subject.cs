using E_LearningSite.API.Models;
using System;

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
