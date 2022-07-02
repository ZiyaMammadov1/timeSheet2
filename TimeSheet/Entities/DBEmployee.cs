namespace TimeSheet.Entities
{
    public class DBEmployee
    {
        public int id { get; set; }

        public int employeeId { get; set; }
        public Employee Employee { get; set; }

        public int databaseId { get; set; }
        public Database Database { get; set; }

        public int companyId { get; set; }
        public Company Company { get; set; }

        public int departmentId { get; set; }
        public Department Depament { get; set; }

        public int projectId { get; set; }
        public Project Project { get; set; }

        public int positionId { get; set; }
        public Position Position { get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }

        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
