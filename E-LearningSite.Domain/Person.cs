using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }
        public int SchoolId { get; set; }

        public AccessRights AccessRights { get; set; }
    }

    public enum AccessRights
    {
        FORMENTORS,
        FORSTUDENTS,
        FORPRINCIPALS
    }
}
