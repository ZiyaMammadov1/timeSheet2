using TimeSheet.Dtos.CompanyDtos;
using TimeSheet.Dtos.DepartmentDtos;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Dtos.ProjectDtos;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.DtosForFront
{
    public class CommonInfoDto
    {
        public string uuid { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fin { get; set; }
        public PositionGetDto Position{ get; set; }
        public CompanyGetDto Company { get; set; }
        public DepartmentGetDto Department { get; set; }
        public ProjectGetDto Project { get; set; }
        public decimal salary { get; set; }
        public string photo { get; set; }
    }

   
}
