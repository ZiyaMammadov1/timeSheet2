using System;

namespace TimeSheet.Entities
{
    public class FamilyMembers : BaseEntity
    {
        public string fin { get; set; }
        public int dbId { get; set; }
        public string relative { get; set; }
        public string fullName { get; set; }
        public DateTime dob { get; set; }
        public string code { get; set; }

    }
}
