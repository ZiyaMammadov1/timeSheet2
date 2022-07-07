using System;
using System.Collections.Generic;

namespace TimeSheet.Dtos.EarnDtos
{
    public class DicEarnGetDto
    {
        public DateTime date { get; set; }

        public Dictionary<string, decimal> earningTypes{ get; set; }
    }
}
