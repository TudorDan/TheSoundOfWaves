using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Student : Person
    {
        public Student() : base()
        {

        }
#nullable enable
        [ForeignKey("CatalogueId")]
        public Catalogue? Catalogue { get; set; }
        public int? CatalogueId { get; set; }
#nullable disable
    }
}
