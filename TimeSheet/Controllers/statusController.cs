using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.StatusDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class statusController : ControllerBase
    {
        private readonly DataContext _context;

        public statusController(DataContext context)
        {
            _context = context;
        }

        Answer<StatusGetDto> getFinishObject;

        [HttpPost]
        public ActionResult<Answer<StatusGetDto>> StatusPost(StatusPostDto postDto)
        {
            if (postDto.code == null || postDto.name == null || postDto.description == null)
            {
                return getFinishObject = new Answer<StatusGetDto>(400, "All field required", null);
            }

            Status newStatus = new Status()
            {
                code = postDto.code,
                description = postDto.description,
                name = postDto.name
            };
            _context.Statuses.Add(newStatus);
            _context.SaveChanges();

            return getFinishObject = new Answer<StatusGetDto>(200, "Status created", null);


        }

        [HttpGet]
        public ActionResult<Answer<StatusGetDto>> GetStatus()
        {
            List<Status> statuses = _context.Statuses.ToList();
            if (statuses == null && statuses.Count <= 0)
            {
                return getFinishObject = new Answer<StatusGetDto>(400, "Statuses not found", null);
            }

            List<StatusGetDto> statusGetDtos = statuses.Select(x => new StatusGetDto() { code = x.code, description = x.description, name = x.name }).ToList();

            return getFinishObject = new Answer<StatusGetDto>(200, "Statuses founded", statusGetDtos);
        }
    }
}
