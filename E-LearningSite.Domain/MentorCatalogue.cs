﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class MentorCatalogue
    {
        public int MentorId { get; set; }
        public int CatalogueId { get; set; }

        public Mentor Mentor { get; set; }
        public Catalogue Catalogue { get; set; }
    }
}
