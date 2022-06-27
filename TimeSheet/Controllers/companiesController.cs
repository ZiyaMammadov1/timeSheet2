//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using TimeSheet.DatabaseContext;
//using TimeSheet.Dtos.CompanyDtos;
//using TimeSheet.Entities;

//namespace TimeSheet.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class companyController : ControllerBase
//    {
//        private readonly DataContext _context;
//        private readonly IMapper _mapper;
//        Answer<CompanyGetDto> getFinishObject;

//        public companyController(DataContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }



//        [HttpPost]
//        public ActionResult<Answer<CompanyGetDto>> CreateCompany(CompanyPostDto CompanyPostDto)
//        {
//            Company newCompany = new Company()
//            {
//                uuid = Guid.NewGuid().ToString(),
//                tin = CompanyPostDto.tin,
//                isDeleted = false,
//                name = CompanyPostDto.name,
//                code = CompanyPostDto.code
//            };
//            _context.Companies.Add(newCompany);
//            _context.SaveChanges();

//            return getFinishObject = new Answer<CompanyGetDto>(201, "Company created", null);
//        }



//        [HttpGet("{tin}")]
//        public ActionResult<Answer<CompanyGetDto>> Get(string tin)
//        {
//            Company exist = _context.Companies.FirstOrDefault(x => x.tin == tin && x.isDeleted == false);
//            if (exist == null)
//            {
//                return getFinishObject = new Answer<CompanyGetDto>(200, "Company doesn't exist", null);
//            }
//            return getFinishObject = new Answer<CompanyGetDto>(200, "Ok", new List<CompanyGetDto> { _mapper.Map<CompanyGetDto>(exist) });
//        }


//        [HttpGet]
//        [Route("properties")]
//        public ActionResult<Answer<string>> GetProperty()
//        {
//            Answer<string> innerFinishObject;

//            List<string> AllProperty = new List<string>();
//            foreach (var property in typeof(Company).GetProperties())
//            {
//                AllProperty.Add(property.Name);   
//            }
//            return innerFinishObject = new Answer<string>(200, "Ok", AllProperty);
//        }

//        [HttpDelete]
//        public ActionResult <Answer<CompanyGetDto>> Delete(string tin)
//        {
//            Company company = _context.Companies.FirstOrDefault(a => a.tin.ToLower() == tin.ToLower() && a.isDeleted == false);
//            if(company == null)
//            {
//                return new Answer<CompanyGetDto>(400,"Company not found",null);
//            }
//            else
//            {
//                company.isDeleted = true;
//                _context.SaveChanges();
//                return new Answer<CompanyGetDto>(200, "Company is deleted", null);

//            }
//        }


//    }
//}
