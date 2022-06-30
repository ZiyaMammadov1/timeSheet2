using FluentValidation;

namespace TimeSheet.Dtos.ProjectDtos
{
    public class ProjectGetDto
    {
        public string name { get; set; }
        public string uuid { get; set; }
        public string code { get; set; }
    }
}
