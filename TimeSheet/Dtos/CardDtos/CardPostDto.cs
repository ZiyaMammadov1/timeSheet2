using System;

namespace TimeSheet.Dtos.CardDtos
{
    public class CardPostDto 
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime expireTime { get; set; }
        public DateTime date { get; set; }
        public string number { get; set; }
        public string issiedBy { get; set; }
        public string address { get; set; }
        public string series { get; set; }
        public string fin { get; set; }
        public string code { get; set; }


    }
}
