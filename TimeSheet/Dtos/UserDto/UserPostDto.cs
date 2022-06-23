using FluentValidation;
using System;

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
        public string position { get; set; }
        public DateTime createdTime { get; set; }
        public string department { get; set; }
        public DateTime dateOfBirthday { get; set; }
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
            RuleFor(x => x.position).NotEmpty().MaximumLength(300);
            RuleFor(x => x.department).NotEmpty().MaximumLength(300);
            RuleFor(x => x.dateOfBirthday).NotEmpty();
        }
    }

}
