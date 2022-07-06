using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.EarnDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class earnController : ControllerBase
    {
        private readonly DataContext _context;
        Answer<EarnGetDto> getFinishObject;

        public earnController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Answer<EarnGetDto>> EarnPost(EarnPostDto earnPostDto)
        {
            List<Earn> earns = _context.Earns.ToList();

            if (earns.Count != 0)
            {
                if (earns.Any(x => x.code == earnPostDto.code))
                {
                    return getFinishObject = new Answer<EarnGetDto>(400, "Earn code conflited", null);
                }
            }
            Database db = _context.Database.FirstOrDefault(x => x.code == earnPostDto.dbCode);

            if (db == null)
            {
                return getFinishObject = new Answer<EarnGetDto>(400, "Database not found", null);
            }

            Employee employee = _context.Employees.FirstOrDefault(x => x.fin == earnPostDto.fin);

            if (employee == null)
            {
                return getFinishObject = new Answer<EarnGetDto>(400, "Employee not found", null);
            }

            Company company = _context.Companies.FirstOrDefault(x => x.tin == earnPostDto.tin && x.databaseId == db.id && x.isDeleted == false);

            if (company == null)
            {
                return getFinishObject = new Answer<EarnGetDto>(400, "Company not found", null);
            }

            EarningType earningType = _context.typeOfEarning.FirstOrDefault(x => x.code == earnPostDto.typeOfEarning && x.dbCode == db.code && x.isDeleted == false);

            if (earningType == null)
            {
                return getFinishObject = new Answer<EarnGetDto>(400, "Earning type not found", null);
            }



            Earn newEarn = new Earn()
            {
                earningTypeId = earningType.id,
                amount = earnPostDto.amount,
                companyId = company.id,
                Date = earnPostDto.Date,
                employeeId = employee.id,
                dbCode = db.code,
                code = earnPostDto.code
            };

            _context.Earns.Add(newEarn);
            _context.SaveChanges();

            return getFinishObject = new Answer<EarnGetDto>(200, "Earn created", null);
        }
    }
}
