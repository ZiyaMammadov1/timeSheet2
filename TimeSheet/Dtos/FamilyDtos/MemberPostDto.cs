using FluentValidation;
using System;

namespace TimeSheet.Dtos.FamilyDtos
{
    public class MemberPostDto
    {
        public string fin { get; set; }
        public string member { get; set; }
        public string memberFullname { get; set; }
        public DateTime memberDoB{ get; set; }
        public DateTime memberAge{ get; set; }
    }

    public class MemberPostDtoValidator : AbstractValidator<MemberPostDto>
    {
        public MemberPostDtoValidator()
        {
            RuleFor(x => x.fin).NotEmpty().MaximumLength(10);
        }
    }
}
