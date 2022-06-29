using System;

namespace TimeSheet.Entities
{
    public class Order : BaseEntity
    {

        public string dbCode { get; set; }
        public string fin { get; set; }
        public string tin { get; set; }
        public string orderType { get; set; }
        public DateTime date { get; set; }
        public DateTime dateEffective { get; set; }
        public DateTime dateExpired { get; set; }
        public DateTime dateTo{ get; set; }
        public int salary1 { get; set; }
        public int salary2 { get; set; }
        public int salaryTotal { get; set; }
        public string description { get; set; }
        public string code { get; set; }


        public int projectId { get; set; }
        public Project Project { get; set; }

        public int deprtmentID { get; set; }
        public Department Department { get; set; }

        public int positionId { get; set; }
        public Position Position { get; set; }

        public int companyId { get; set; }
        public Company Company { get; set; }

    }
}
