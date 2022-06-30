using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.FamilyDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class familyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<MemberGetDto> getFinishObject;

        public familyController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //[HttpPost]
        //public ActionResult<Answer<MemberGetDto>> CreateMember(MemberPostDto memberPostDto)
        //{
        //    Database database = _context.Database.FirstOrDefault(a => a.code.ToLower() == memberPostDto.dbCode.ToLower());
        //    if (database == null)
        //    {
        //        return getFinishObject = new Answer<MemberGetDto>(400, "Database not found.", null);
        //    }

        //    Employee employee = _context.Employees.FirstOrDefault(a => a.fin == memberPostDto.fin);
        //    if (database == null)
        //    {
        //        return getFinishObject = new Answer<MemberGetDto>(400, "Employee not found.", null);
        //    }

        //FamilyMembers newMember = new FamilyMembers()
        //{
        //    member = memberPostDto.member,
        //    age = memberPostDto.memberAge,
        //    dob = memberPostDto.memberDoB,
        //    fullName = memberPostDto.memberFullname,
        //    userId = user.id
        //};

        //_context.FamilyMembers.Add(newMember);
        //_context.SaveChanges();

        //return getFinishObject = new Answer<MemberGetDto>(201, "Member created.", null);

    //}





    }
}


