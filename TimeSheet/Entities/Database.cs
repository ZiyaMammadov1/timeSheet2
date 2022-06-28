using System;
using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Database : BaseEntity
    {
        public string name { get; set; }
        public string server { get; set; }
        public string port { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Position> Positions { get; set; } = new List<Position>();
        public List<Company> Companies { get; set; } = new List<Company>();

    }
}
