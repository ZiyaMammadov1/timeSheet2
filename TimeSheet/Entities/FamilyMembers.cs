using System;

namespace TimeSheet.Entities
{
    public class FamilyMembers
    {
        public int id { get; set; }
        public string member { get; set; }
        public string fullName { get; set; }
        public DateTime dob { get; set; }
        public int age { get; set; }

        public int userId { get; set; }
        public Employee User { get; set; }

    }
}
