using System;

namespace TimeSheet.Entities
{
    public class RefreshToken
    {
        public int id { get; set; }
        public int employeeId { get; set; }
        public Employee Employee { get; set; }
        public string RefreshTokenString { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
    }
}
