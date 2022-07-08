using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.RequestTypeDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class requestTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public requestTypeController(DataContext context)
        {
            _context = context;
        }

        Answer<RequestTypeGetDto> getFinishObject;

        [HttpPost]
        public ActionResult<Answer<RequestTypeGetDto>> StatusPost(RequestTypePostDto postDto)
        {
            if (postDto.code == null || postDto.name == null || postDto.description == null)
            {
                return getFinishObject = new Answer<RequestTypeGetDto>(400, "All field required", null);
            }

            RequestType newRequest = new RequestType()
            {
                code = postDto.code,
                description = postDto.description,
                name = postDto.name
            };
            _context.RequestTypes.Add(newRequest);
            _context.SaveChanges();

            return getFinishObject = new Answer<RequestTypeGetDto>(200, "RequestType created", null);


        }

        [HttpGet]
        public ActionResult<Answer<RequestTypeGetDto>> GetStatus()
        {

            List<RequestType> types = _context.RequestTypes.ToList();
            if (types == null && types.Count <= 0)
            {
                return getFinishObject = new Answer<RequestTypeGetDto>(400, "RequestType not found", null);
            }

            List<RequestTypeGetDto> requestGetDtos = types.Select(x => new RequestTypeGetDto() { code = x.code, description = x.description, name = x.name }).ToList();

            return getFinishObject = new Answer<RequestTypeGetDto>(200, "Request types founded", requestGetDtos);
        }
    }
}
