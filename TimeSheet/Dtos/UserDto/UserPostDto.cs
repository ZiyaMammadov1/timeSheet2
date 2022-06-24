using FluentValidation;
using System;
using System.Collections.Generic;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.UserDto
{
    public class UserPostDto
    {
        public string cid { get; set; }
        public string fin { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string positionCode { get; set; }
        public string projectCode { get; set; }

        public DateTime createdTime { get; set; }
        public string departmentCode { get; set; }
        public DateTime dob { get; set; }
        public string photo { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string phone4 { get; set; }

    }

    public class UserPostDtoValidator : AbstractValidator<UserPostDto>
    {
        public UserPostDtoValidator()
        {
            RuleFor(x => x.fin).NotEmpty().MaximumLength(10);
            RuleFor(x => x.email).MaximumLength(150);
            RuleFor(x => x.password).NotEmpty().MaximumLength(150);
            RuleFor(x => x.firstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.lastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.positionCode).NotEmpty().MaximumLength(300);
            RuleFor(x => x.departmentCode).NotEmpty().MaximumLength(300);
        }
    }

}
