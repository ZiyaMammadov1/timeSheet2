namespace TimeSheet.Entities
{
    public class OrderTypes
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string info { get; set; }
        public bool isDeleted { get; set; }
    }
}
