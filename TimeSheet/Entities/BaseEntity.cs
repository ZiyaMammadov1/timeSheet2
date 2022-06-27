using System;

namespace TimeSheet.Entities
{
    public class BaseEntity
    {
        public int id { get; set; }
        public string uuid
        {
            get => uuid;
            set => uuid = Guid.NewGuid().ToString();
        }
        public string code { get; set; }
        public bool isdDeleted { get; set; }
    }
}
