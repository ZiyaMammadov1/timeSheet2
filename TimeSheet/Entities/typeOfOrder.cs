using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class typeOfOrder : BaseEntity
    {
        public string name { get; set; }
        public string description { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
