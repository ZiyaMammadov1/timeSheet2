using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.EarningDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class earningController : ControllerBase
    {
        private readonly DataContext _context;

        public earningController(DataContext context)
        {
            _context = context;
        }

        Answer<EarningGetDto> getFinishObject;

        [HttpPost]
        public ActionResult<Answer<EarningGetDto>> EarningPost(EarningPostDto postDto)
        {
            List<EarningType> earnList = _context.typeOfEarning.ToList();
            Database database = _context.Database.FirstOrDefault(x => x.code == postDto.dbCode);
            if (database == null)
            {
                return getFinishObject = new Answer<EarningGetDto>(400, "Database not found", null);
            }
            if (earnList.Any(x => x.code == postDto.code))
            {
                return getFinishObject = new Answer<EarningGetDto>(400, "Code conflict", null);
            }
            EarningType newEarning = new EarningType()
            {
                code = postDto.code,
                dbCode = postDto.dbCode,
                name = postDto.name
            };
            _context.typeOfEarning.Add(newEarning);
            _context.SaveChanges();
            return getFinishObject = new Answer<EarningGetDto>(200, "Salary type created", null);


        }

        //[HttpGet]
        //public ActionResult<List<EarningGetDto>> GetAll()
        //{
        //    List<EarningType> earningTypes = _context.typeOfEarning.ToList();
        //    if(earningTypes.Count == 0)
        //    {
        //        return getFinishObject = new Answer<List<EarningGetDto>>(400, "EarninhType not found", null);
        //    }


        //}
    }
}
