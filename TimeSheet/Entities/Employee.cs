using System;
using System.Collections.Generic;

namespace TimeSheet.Entities
{
    public class Employee : BaseEntity
    {
        public string fin { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime date { get; set; }
        public DateTime expireDate { get; set; }
        public int number { get; set; }
        public string seriya { get; set; }
        public string adress { get; set; }
        public string issiedBy { get; set; }
        public string photo { get; set; }
        public string dbCode { get; set; }
        public string email { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string phone4 { get; set; }
        public string isActive { get; set; }

        public List<DbEmployee> DbEmployees { get; set; } = new List<DbEmployee>();
        public List<Card> Cards { get; set; } = new List<Card>();

    }

}
