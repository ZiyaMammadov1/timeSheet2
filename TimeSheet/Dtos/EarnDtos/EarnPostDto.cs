using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Dtos.EarnDtos
{
    public class EarnPostDto
    {
        public string dbCode { get; set; }
        public string fin { get; set; }
        public string tin { get; set; }
        public string code { get; set; }
        public DateTime Date { get; set; }
        public string typeOfEarning { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
    }
}
