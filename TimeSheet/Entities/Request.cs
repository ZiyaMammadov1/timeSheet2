using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Entities
{
    public class Request
    {
        public int id { get; set; }

        public int employeeId { get; set; }
        public Employee Employee { get; set; }

        public int companyId { get; set; }
        public Company Company { get; set; }


        public int databaseId { get; set; }
        public Database Database { get; set; }

        public int requestTypeId { get; set; }
        public RequestType RequestType { get; set; }

        public int statusId { get; set; }
        public Status Status { get; set; }

        public string code { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime dateTo { get; set; }
        public DateTime dateFrom { get; set; }
        public string description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }

    }
}
