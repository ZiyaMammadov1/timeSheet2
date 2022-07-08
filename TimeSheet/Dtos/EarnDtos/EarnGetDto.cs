using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TimeSheet.Dtos.CompanyDtos;
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

    public class monthDto
    {
        public int year { get; set; }
        public int id { get; set; }
        public bool earningtype { get; set; }

        public string dbCode { get; set; }
        public DateTime date { get; set; }
     

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
    }

    public class yearDto
    {
        public int id { get; set; }
        public CompanyGetDto company { get; set; }
        public List<monthDto>  months { get; set; }
    }
}
