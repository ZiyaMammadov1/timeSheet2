using FluentValidation;
using System;
using System.Collections.Generic;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.UserDto
{
    public class EmployeePostDto
    {
        public string code { get; set; }
        public string fin { get; set; }
    }

    public class UserPostDtoValidator : AbstractValidator<EmployeePostDto>
    {
        public UserPostDtoValidator()
        {

        }
    }

}
