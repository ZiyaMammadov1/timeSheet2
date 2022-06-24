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
    public class companiesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<CompanyGetDto> getFinishObject;

        public companiesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("addlist")]
        public ActionResult<Answer<CompanyGetDto>> CreateCompaniesFromList(List<CompanyPostDto> companiesPostDto)
        {
            List<Company> correctCompanies = new List<Company>();
            List<CompanyGetDto> errorCompanies = new List<CompanyGetDto>();
            Answer<CompanyGetDto> innerFinishObject;


            foreach (var company in companiesPostDto)
            {
                if((company.name == "" || company.tin == "" || company.voen == "")|| (company.name == null || company.tin == null || company.voen == null))
                {
                    CompanyGetDto currentCompany = new CompanyGetDto()
                    {
                        name = company.name,
                        tin = company.tin,
                        voen = company.voen
                    };
                    errorCompanies.Add(currentCompany);
                }
                else
                {
                    Company newCompany = new Company()
                    {
                        uuid = Guid.NewGuid().ToString(),
                        isDeleted = false,
                        name = company.name,
                        tin = company.tin,
                        voen = company.voen,
                    };
                    correctCompanies.Add(newCompany);
                }

            }

            _context.Companies.AddRange(correctCompanies);
            _context.SaveChanges();
            return innerFinishObject = new Answer<CompanyGetDto>(200, "Correct companies added. Incorrect entered datas:", errorCompanies);
        }

    }
}
