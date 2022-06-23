using System;

namespace TimeSheet.Entities
{
    public class FamilyMembers
    {
        public int id { get; set; }
        public string member { get; set; }
        public string memberFullName { get; set; }
        public DateTime MyProperty { get; set; }

        public int userId { get; set; }
        public User User { get; set; }


    }
}
