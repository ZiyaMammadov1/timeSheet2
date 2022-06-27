using FluentValidation;

namespace TimeSheet.Dtos.DepartmentDtos
{
    public class DepartmentUpdateDto
    {
        public string code { get; set; }
        public string name { get; set; }
    }
   
}
