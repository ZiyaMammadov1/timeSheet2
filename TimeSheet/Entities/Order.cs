using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Entities
{
    public class Order : BaseEntity
    {

        public string dbCode { get; set; }
        public string fin { get; set; }
        public string tin { get; set; }
        public string orderType { get; set; }
        public DateTime date { get; set; }
        public DateTime dateEffective { get; set; }
        public DateTime dateExpired { get; set; }
        public DateTime dateTo { get; set; }
        public DateTime dateFrom { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? days { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? totalDays { get; set; }
        public string place { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal salary1 { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal salary2 { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal salaryTotal { get; set; }
        public string description { get; set; }
        public string code { get; set; }


        public int projectId { get; set; }
        public Project Project { get; set; }

        public int deprtmentID { get; set; }
        public Department Deprtment { get; set; }

        public int positionId { get; set; }
        public Position Position { get; set; }

        public int companyId { get; set; }
        public Company Company { get; set; }

    }
}
