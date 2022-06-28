﻿using System;
using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Employee : BaseEntity
    {
        public string fin { get; set; }
        public string password { get; set; }

        public List<DbEmployee> DbEmployees { get; set; } = new List<DbEmployee>();

    }

}
