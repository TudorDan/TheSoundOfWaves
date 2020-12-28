using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningSite.Domain
{
    public class Subject
    {
        public Subject()
        {
            //Id = -1;
            Courses = new List<Course>();
        }

        public Subject(int id, string name, SubjectType subjectType)
        {
            this.Id = id;
            this.Name = name;
            this.SubjectType = subjectType;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        /*{
            get
            {
                return Enum.GetName(typeof(Type), SubjectType);
            }
            private set
            {
                Name = this.SubjectType.ToString();
            }
        }*/

        public SubjectType SubjectType { get; set; }
        public List<Course> Courses { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }
        public int SchoolId { get; set; }
    }

    public enum SubjectType : int
    {
        HISTORY,
        IT,
        ASTRONOMY,
        PHYSICS,
        GEOGRAPHY,
        MATHEMATICS,
        SCIENCE
    }
}
