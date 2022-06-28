using FluentValidation;
using System;
using System.Collections.Generic;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.UserDto
{
    public class EmployeePostDto
    {
        public string fin { get; set; }
        public string password { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime date { get; set; }
        public DateTime expireDate { get; set; }
        public string number { get; set; }
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

    public class UserPostDtoValidator : AbstractValidator<EmployeePostDto>
    {
        public UserPostDtoValidator()
        {

        }
    }

}
