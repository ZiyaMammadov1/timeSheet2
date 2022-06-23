using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Dtos.FamilyDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class familyController : ControllerBase
    {
        [HttpPost]
        public ActionResult <Answer<MemberGetDto>> CreateMember(MemberPostDto memberPostDto)
        {
            return Ok("asd");
        }
    }
}
