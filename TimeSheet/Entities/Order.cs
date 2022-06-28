using System;

namespace TimeSheet.Entities
{
    public class Order : BaseEntity
    {
        public int employeeId{ get; set; }
        public Employee Employee{ get; set; } 
        
        public int companyId{ get; set; }
        public Company Company{ get; set; }

        public int databaseId { get; set; }
        public Database Database { get; set; }

        public int projectId { get; set; }
        public Project Project{ get; set; }

        public int departmentId { get; set; }
        public Department Department { get; set; }

        public string salary1 { get; set; }
        public string salary2 { get; set; }
        public string salaryTotal { get; set; }

        public string description { get; set; }
        public DateTime expiryDate { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo{ get; set; }


    }
}
