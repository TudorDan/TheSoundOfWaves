using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Mentor : Person
    {
        public Mentor() : base()
        {
            MentorCatalogues = new List<MentorCatalogue>();
        }

        public List<MentorCatalogue> MentorCatalogues { get; set; }
    }
}
