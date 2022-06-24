namespace TimeSheet.Entities
{
    public class Department
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public bool  isDeleted { get; set; }
        public string code { get; set; }
        public string codeUR { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
