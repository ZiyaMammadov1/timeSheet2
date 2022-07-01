using System;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.OrderDtos
{
    public class OrderGetDto
    {
        public string dbCode { get; set; }
        public string fin { get; set; }
        public string tin { get; set; }
        public typeOfOrder orderType { get; set; }
        public DateTime date { get; set; }
        public DateTime dateEffective { get; set; }
        public DateTime dateExpired { get; set; }
        public DateTime dateTo { get; set; }
        public decimal salary1 { get; set; }
        public decimal salary2 { get; set; }
        public decimal salaryTotal { get; set; }
        public string description { get; set; }
        public string code { get; set; }

        public Project Project { get; set; }
        public Department Department { get; set; }
        public Position Position{ get; set; }
        public Company Company{ get; set; }
    }
}
