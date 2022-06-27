using FluentValidation;

namespace TimeSheet.Dtos.PositionDtos
{
    public class PositionPostDto
    {
        public string name { get; set; }
        public string code { get; set; }
        public string dbCode { get; set; }
    }
  
}
