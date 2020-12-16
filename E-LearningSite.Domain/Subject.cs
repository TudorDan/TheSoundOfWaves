using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningSite.Domain
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SubjectName
        {
            get
            {
                return Enum.GetName(typeof(Type), SubjectType);
            }
            private set
            {
                SubjectName = this.SubjectType.ToString();
            }
        }

        public SubjectType SubjectType { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }
        public int SchoolId { get; set; }
    }

    public enum SubjectType
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
