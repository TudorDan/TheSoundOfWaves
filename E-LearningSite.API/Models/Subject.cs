﻿using E_LearningSite.API.Models;
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
    }
}
