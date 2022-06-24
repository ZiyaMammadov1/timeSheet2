using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Company
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string tin { get; set; }
        public bool isDeleted { get; set; }
        public string code { get; set; }

        public List<Project> companyProjects { get; set; } = new List<Project>();
        public List<User> companyUsers { get; set; } = new List<User>();
        public List<Department> companyDepartment { get; set; } = new List<Department>();

    }
}
