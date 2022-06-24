using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public ActionResult<Answer<CompanyGetDto>> CreateCompany(CompanyPostDto companiesPostDto)
        {

            Company newCompany = new Company()
            {
                uuid = Guid.NewGuid().ToString(),
                isDeleted = false,
                name = companiesPostDto.name,
                tin = companiesPostDto.tin,
                voen = companiesPostDto.voen,
            };
            _context.Companies.Add(newCompany);
            _context.SaveChanges();
            return getFinishObject = new Answer<CompanyGetDto>(201, "Company added", null);
        }

    }
}
