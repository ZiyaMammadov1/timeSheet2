using System;

namespace TimeSheet.Entities
{
    public class Card : BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime expireTime { get; set; }
        public DateTime date { get; set; }
        public string number { get; set; }
        public string issiedBy { get; set; }
        public string address { get; set; }
        public string series { get; set; }
        public bool isActive { get; set; }


        public int employeeId { get; set; }
        public Employee employee{ get; set; }
    }
}
