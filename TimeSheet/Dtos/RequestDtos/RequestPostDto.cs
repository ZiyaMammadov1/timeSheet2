using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Dtos.RequestDtos
{
    public class RequestPostDto
    {
        public string fin { get; set; }
        public string tin { get; set; }
        public string dbCode { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public DateTime date { get; set; }
        public DateTime dateTo { get; set; }
        public DateTime dateFrom { get; set; }
        public string description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
    }
}
