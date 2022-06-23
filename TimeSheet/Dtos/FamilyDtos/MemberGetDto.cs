using System;

namespace TimeSheet.Dtos.FamilyDtos
{
    public class MemberGetDto
    {
        public string member { get; set; }
        public string memberFullname { get; set; }
        public DateTime memberDoB { get; set; }
        public DateTime memberAge { get; set; }
    }
}
