using System;
using TimeSheet.Dtos.PositionDtos;

namespace TimeSheet.Dtos.UserDto
{
    public class EmployeeGetDto
    {
        public string fin { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime date { get; set; }
        public DateTime expireDate { get; set; }
        public int number { get; set; }
        public string seriya { get; set; }
        public string adress { get; set; }
        public string issiedBy { get; set; }
        public string photo { get; set; }
        public string dbCode { get; set; }
        public string email { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string phone4 { get; set; }
    }
}
