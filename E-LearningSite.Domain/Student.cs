﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Student : Person
    {
        public Student() : base()
        {

        }

        public Catalogue Catalogue { get; set; }
        public int CatalogueId { get; set; }
    }
}