using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Entities
{
    public class Earn
    {
        public int id { get; set; }
        public string code { get; set; }
        public string uuid { get; set; }
        public string dbCode { get; set; }
        public int employeeId { get; set; }
        public Employee Employee { get; set; }
        public int companyId { get; set; }
        public Company Company { get; set; }
        public DateTime Date { get; set; }
        public int earningTypeId { get; set; }
        public EarningType EarningType{ get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
        public bool isDeleted { get; set; }
    }
}
