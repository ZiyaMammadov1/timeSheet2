namespace TimeSheet.Entities
{
    public class Company
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string voen { get; set; }
        public string tin { get; set; }
        public bool isDeleted { get; set; }
    }
}
