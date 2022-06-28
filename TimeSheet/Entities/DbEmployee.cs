namespace TimeSheet.Entities
{
    public class DbEmployee :  BaseEntity
    {
        public bool isActive { get; set; }

        public int employeeId { get; set; }
        public Employee employee{ get; set; }

        public int databaseId { get; set; }
        public Database Database{ get; set; }

        public int companyId { get; set; }
        public Company Company { get; set; }
    }
}
