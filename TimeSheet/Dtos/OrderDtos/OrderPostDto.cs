using System;

namespace TimeSheet.Dtos.OrderDtos
{
    public class OrderPostDto
    {

        public string dbCode { get; set; }
        public string fin { get; set; }
        public string tin { get; set; }
        public string orderType { get; set; }
        public DateTime date { get; set; }
        public DateTime dateEffective { get; set; }
        public DateTime dateExpired { get; set; }
        public DateTime dateTo { get; set; }
        public int salary1 { get; set; }
        public int salary2 { get; set; }
        public int salaryTotal { get; set; }
        public string description { get; set; }
        public string code { get; set; }

        public string projectCode { get; set; }
        public string departmentCode { get; set; }
        public string positionCode { get; set; }



    }
}
