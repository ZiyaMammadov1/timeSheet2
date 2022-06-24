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



        [HttpPost]
        public ActionResult<Answer<CompanyGetDto>> CreateProject(CompanyPostDto CompanyPostDto)
        {
            Company newCompany = new Company()
            {
                uuid = Guid.NewGuid().ToString(),
                tin = CompanyPostDto.tin,
                isDeleted = false,
                name = CompanyPostDto.name
            };
            _context.Companies.Add(newCompany);
            _context.SaveChanges();

            return getFinishObject = new Answer<CompanyGetDto>(201, "Department created", null);
        }


    }
}
