using TimeSheet.Dtos.OrderDtos;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.CreateOrRemoveDtos
{
    public class CreateOrRemoveDto
    {
        public OrderPostDto OrderPostDto { get; set; }
        public Project Project { get; set; }
        public Department Department { get; set; }
        public Company Company { get; set; }
        public Position Position { get; set; }
        public Database Database { get; set; }
        public Employee Employee { get; set; }
    }
}
