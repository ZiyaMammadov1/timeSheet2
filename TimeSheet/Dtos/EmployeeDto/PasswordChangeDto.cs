using FluentValidation;

namespace TimeSheet.Dtos.UserDto
{
    public class PasswordChangeDto
    {
        public string code { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

   
}
