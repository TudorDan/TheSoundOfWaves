using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public enum AccessRights
    {
        FORMENTORS = 0,
        FORSTUDENTS = 1,
        FORPRINCIPALS = 2,
        FORADMIN = 3,
        FORGUEST = 4,
    }
}
