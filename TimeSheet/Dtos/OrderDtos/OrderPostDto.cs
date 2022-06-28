using System;

namespace TimeSheet.Dtos.OrderDtos
{
    public class OrderPostDto
    {
        public string fin { get; set; }
        public string companyTin { get; set; }
        public string dbCode { get; set; }
        public string typeCode { get; set; }
        public string projectCode { get; set; }
        public string departmentCode { get; set; }
        public string salary1 { get; set; }
        public string salary2 { get; set; }
        public string salaryTotal { get; set; }
        public string description { get; set; }
        public DateTime expiryDate { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }

    }
}
