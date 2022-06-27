using TimeSheet.Dtos.TimeİntervalDtos;

namespace TimeSheet.Entities
{
    public class UserWithTimeInterval
    {
        public TimeIntervalGetDto timeInterval { get; set; }
        public Employee user { get; set; }
    }
}
