using System;
using System.ComponentModel.DataAnnotations.Schema;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.EarnDtos
{
    public class EarnGetDto
    {
        public string uuid { get; set; }
        public string dbCode { get; set; }
        public string employeeId { get; set; }
        public string companyId { get; set; }
        public DateTime Date { get; set; }
        public int earningTypeId { get; set; }
        public EarningType EarningType { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
        public bool isDeleted { get; set; }
    }
}
