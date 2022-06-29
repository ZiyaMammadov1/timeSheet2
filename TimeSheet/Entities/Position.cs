using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Position : BaseEntity
    {
        public string name { get; set; }

        public int databaseId { get; set; }
        public Database Database { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<DBEmployee> dBEmployees { get; set; } = new List<DBEmployee>();

    }
}
