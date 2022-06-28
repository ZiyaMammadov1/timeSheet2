using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Entities
{
    public class Company : BaseEntity
    {
        public string tin { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }

        public int databaseId { get; set; }
        public Database Database { get; set; }

    }
}
