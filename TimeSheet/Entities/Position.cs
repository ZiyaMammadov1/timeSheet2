namespace TimeSheet.Entities
{
    public class Position : BaseEntity
    {
        public string name { get; set; }

        public int databaseId { get; set; }
        public Database Database { get; set; }
    }
}
