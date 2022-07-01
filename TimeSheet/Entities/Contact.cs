namespace TimeSheet.Entities
{
    public class Contact : BaseEntity
    {
        public int dbId { get; set; }
        public string email { get; set; }
        public int employeeId { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string phone4 { get; set; }

    }
}
