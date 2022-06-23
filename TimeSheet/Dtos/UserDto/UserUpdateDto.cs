using FluentValidation;

namespace TimeSheet.Dtos.UserDto
{
    public class UserUpdateDto
    {
        public string id { get; set; }
        public string cid { get; set; }
        public string fin { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int positionId { get; set; }
        public string photo { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string phone4 { get; set; }
    }

    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.id).NotEmpty().MaximumLength(100);
            RuleFor(x => x.fin).NotEmpty().MaximumLength(10);
            RuleFor(x => x.cid).MaximumLength(50);
            RuleFor(x => x.email).NotEmpty().MaximumLength(150);
            RuleFor(x => x.firstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.lastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.positionId).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
