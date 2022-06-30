using System;

namespace TimeSheet.Dtos.FamilyDtos
{
    public class MemberGetDto
    {
        public string relative { get; set; }
        public string fullName { get; set; }
        public DateTime dob { get; set; }

    }
}
