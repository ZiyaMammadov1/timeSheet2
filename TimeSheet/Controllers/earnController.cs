using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.CompanyDtos;
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
        private readonly IMapper _mapper;

        public earnController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        [HttpGet]
        public ActionResult<Answer<monthDto>> GetEarn(string fin, Guid? uuid)
        {
            Answer<Dictionary<string, decimal>> getFinishObjectForMethod;

            Answer<monthDto> getFinishObjectForDict;

            Employee employee = _context.Employees.FirstOrDefault(x => x.fin == fin && x.isDeleted == false);
            if (employee == null)
            {
                return getFinishObjectForDict = new Answer<monthDto>(200, "Employee not found", null);
            }
            List<DBEmployee> dbEmployees = _context.dBEmployees.Include(x => x.Company).Include(x => x.Database).Where(a => a.employeeId == employee.id).ToList();

            if (dbEmployees == null || dbEmployees.Count <= 0)
            {
                return getFinishObjectForDict = new Answer<monthDto>(400, "DbEmployees not found.", null);
            }

            DBEmployee dBEmployee = dbEmployees.FirstOrDefault();
            int dbId;
            if (uuid != null)
            {
                dBEmployee = dbEmployees.FirstOrDefault(x => x.Company.uuid.ToLower() == uuid.ToString());
            }
            dbId = dBEmployee.databaseId;

            List<Earn> earns = _context.Earns.Include(x => x.EarningType).Where(x => x.employeeId == employee.id && x.dbCode == dBEmployee.Database.code).ToList();

            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();
            EarningType earntype = new EarningType();
            DicEarnGetDto response = new DicEarnGetDto();

            monthDto month = new monthDto();

            List<monthDto> months = new List<monthDto>();

            foreach (var earn in earns)
            {
                if (dict.ContainsKey(earn.EarningType.name))
                {
                    dict[earn.EarningType.name] += Math.Abs(earn.amount);
                }
                else
                {
                    dict.Add(earn.EarningType.name, Math.Abs(earn.amount));
                }
                month = new monthDto()
                {
                    year = earn.Date.Year,
                    id = earn.Date.Month,
                    amount = earn.amount,
                    date = earn.Date,
                    dbCode = earn.dbCode,
                    earningTypes = dict
                };
                dict = new Dictionary<string, decimal>();
                months.Add(month);
            }

            List<DicEarnGetDto> results = new List<DicEarnGetDto>();
            List<yearDto> years = new List<yearDto>();



            return getFinishObjectForDict = new Answer<monthDto>(200, "Earn founded", months);

        }


    }
}
