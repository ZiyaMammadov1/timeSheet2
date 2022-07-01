using System;

namespace TimeSheet.Dtos.CardDtos
{
    public class CardGetDto
    {
        public string fin { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime date { get; set; }
        public DateTime expireDate { get; set; }
        public string number { get; set; }
        public string seriya { get; set; }
        public string adress { get; set; }
        public string issiedBy { get; set; }
        public string photo { get; set; }
    }
}
