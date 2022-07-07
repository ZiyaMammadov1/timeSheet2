using System;
using TimeSheet.Dtos.CompanyDtos;
using TimeSheet.Dtos.DepartmentDtos;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Dtos.ProjectDtos;
using TimeSheet.Dtos.TypeOfOrderDtos;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.OrderDtos
{
    public class OrderGetDto
    {
        public string dbCode { get; set; }
        public string fin { get; set; }
        public string tin { get; set; }
        public typeOfOrderGetDto orderType { get; set; }
        public DateTime date { get; set; }
        public DateTime dateEffective { get; set; }
        public DateTime dateExpired { get; set; }
        public DateTime dateTo { get; set; }
        public decimal salary1 { get; set; }
        public decimal salary2 { get; set; }
        public decimal salaryTotal { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public ProjectGetDto Project { get; set; }
        public DepartmentGetDto Department { get; set; }
        public PositionGetDto Position { get; set; }
        public CompanyGetDto Company { get; set; }
    }
}
