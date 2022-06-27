using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Project:BaseEntity
    {
        public string name { get; set; }

        public int databaseId { get; set; }
        public Database Database { get; set; }
    }
}
