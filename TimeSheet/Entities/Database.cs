using System;
using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Database : BaseEntity
    {
        public string name { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Project> Projects { get; set; } = new List<Project>();

    }
}
