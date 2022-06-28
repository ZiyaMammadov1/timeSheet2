namespace TimeSheet.Dtos.CompanyDtos
{
    public class CompanyGetDto
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string tin { get; set; }
        public bool isActive { get; set; }
        public string dbCode { get; set; }

    }
}
