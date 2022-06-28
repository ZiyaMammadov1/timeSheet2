namespace TimeSheet.Entities
{
    public class Department : BaseEntity
    {
        public string name { get; set; }
        public string tin { get; set; }
        public int databaseId { get; set; }
        public Database Database { get; set; }
    }
}
