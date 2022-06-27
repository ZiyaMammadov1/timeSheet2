using System;

namespace TimeSheet.Entities
{
    public class RefreshToken
    {
        public int id { get; set; }
        public int Userid { get; set; }
        public Employee User { get; set; }
        public string RefreshTokenString { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
    }
}
