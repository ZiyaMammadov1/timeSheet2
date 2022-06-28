using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.CompanyDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class companyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<CompanyGetDto> getFinishObject;

        public companyController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<Answer<CompanyGetDto>> GetAll()
        {
            List<Company> companies = _context.Companies.Where(x => x.isDeleted == false).ToList();

            if (companies.Count > 0)
            {
                List<CompanyGetDto> companyList = new List<CompanyGetDto>();
                foreach (var company in companies)
                {
                    Database databases = _context.Database.FirstOrDefault(x => x.isDeleted == false);

                    CompanyGetDto GetDto = new CompanyGetDto() 
                    {
                        uuid = company.uuid,
                        name=company.name,
                        tin = company.tin,
                        dbCode = databases.code
                    };
                    companyList.Add(GetDto);
                }
                return getFinishObject = new Answer<CompanyGetDto>(200, "Companies founded", companyList);
            }
            return getFinishObject = new Answer<CompanyGetDto>(400, "Companies not founded", null);
        }

        [HttpGet("{code}")]
        public ActionResult<Answer<CompanyGetDto>> Get(string code)
        {
            Company company = _context.Companies.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);

            Database database = _context.Database.FirstOrDefault(x=>x.id == company.databaseId && x.isDeleted == false);

            if (company != null)
            {
                CompanyGetDto currentCompany = new CompanyGetDto()
                {
                    dbCode = database.code,
                    name = company.name,
                    isActive = company.isActive,
                    tin = company.tin,
                    uuid = company.uuid
                };
                return getFinishObject = new Answer<CompanyGetDto>(200, "Companies founded", new List<CompanyGetDto> { currentCompany });
            }
            else
            {
                return getFinishObject = new Answer<CompanyGetDto>(400, "Companies not found", null);
            }
        }
        
        [HttpPost]
        public ActionResult<Answer<CompanyGetDto>> CreateCompany(CompanyPostDto CompanyPostDto)
        {
            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == CompanyPostDto.dbCode.ToLower() && x.isDeleted == false);

            if (database == null)
            {
                return getFinishObject = new Answer<CompanyGetDto>(400, "Database not found", null);
            }

            if (_context.Companies.Any(x => x.name.ToLower() == CompanyPostDto.name.ToLower() && x.databaseId == database.id))
            {
                return getFinishObject = new Answer<CompanyGetDto>(409, "This company existed", null);
            }

            Company company = new Company() { name = CompanyPostDto.name, code = CompanyPostDto.code, databaseId = database.id, tin = CompanyPostDto.tin  };

            _context.Companies.Add(company);
            _context.SaveChanges();

            return getFinishObject = new Answer<CompanyGetDto>(201, "Company created", null);
        }

        [HttpPut]
        public ActionResult<Answer<CompanyGetDto>> UpdateCompany(CompanyUpdateDto CompanyUpdateDto)
        {
            Company company = _context.Companies.FirstOrDefault(x => x.code.ToLower() == CompanyUpdateDto.code.ToLower() && x.isDeleted == false);

            if (company == null)
            {
                return getFinishObject = new Answer<CompanyGetDto>(400, "Company not found", null);
            }

            company.name = CompanyUpdateDto.name;
            company.tin = CompanyUpdateDto.tin;

            _context.SaveChanges();

            return getFinishObject = new Answer<CompanyGetDto>(204, "Company updated", null);
        }

        [HttpPost("{deactive}")]
        public ActionResult<Answer<CompanyGetDto>> SetDeactive(string deactive)
        {
            Company company = _context.Companies.FirstOrDefault(x => x.code.ToLower() == deactive.ToLower() && x.isDeleted == false);

            if (company != null)
            {
                company.isActive = false;
                _context.SaveChanges();
                return getFinishObject = new Answer<CompanyGetDto>(200, "Company set deactive",null);
            }
            else
            {
                return getFinishObject = new Answer<CompanyGetDto>(400, "Company not found", null);
            }
        }

        [HttpDelete]
        public ActionResult<Answer<CompanyGetDto>> Delete(string code)
        {
            Company company = _context.Companies.FirstOrDefault(a => a.code.ToLower() == code.ToLower() && a.isDeleted == false);
            if (company == null)
            {
                return new Answer<CompanyGetDto>(400, "Company not found", null);
            }
            else
            {
                company.isDeleted = true;
                _context.SaveChanges();
                return new Answer<CompanyGetDto>(200, "Company deleted", null);

            }
        }


    }
}
