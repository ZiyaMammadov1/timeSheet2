using AutoMapper;
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


        [HttpPost]
        public ActionResult<Answer<MemberGetDto>> CreateMember(MemberPostDto memberPostDto)
        {
            Database database = _context.Database.FirstOrDefault(a => a.code == memberPostDto.dbCode && a.isDeleted == false);
            if (database == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "Database not found.", null);
            }

            Employee employee = _context.Employees.FirstOrDefault(a => a.fin == memberPostDto.fin);
            if (employee == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "Employee not found.", null);
            }
            List<FamilyMembers> existMembers = _context.FamilyMembers.Where(x => x.dbId == database.id && x.fin == employee.fin && x.isDeleted == false).ToList();

            foreach (var member in existMembers)
            {
                if (member.fullName == null || member.code == null )
                {
                    return getFinishObject = new Answer<MemberGetDto>(400, "Fullname and code can't be null", null);
                }
                if (member.code == memberPostDto.code)
                {
                    return getFinishObject = new Answer<MemberGetDto>(409, "A code conflict occurred", null);
                }
                if (member.fullName.ToLower() == memberPostDto.fullName.ToLower() && member.dbId == database.id)
                {
                    member.relative = memberPostDto.relative;
                    member.dob = memberPostDto.dob;
                    member.fullName = memberPostDto.fullName;

                    _context.SaveChanges();
                    return getFinishObject = new Answer<MemberGetDto>(201, "Member updated.", null);
                }
               

            }

            FamilyMembers newMember = new FamilyMembers()
            {
                relative = memberPostDto.relative,
                dbId = database.id,
                code = memberPostDto.code,
                dob = memberPostDto.dob,
                fullName = memberPostDto.fullName,
                fin = memberPostDto.fin
            };

            _context.FamilyMembers.Add(newMember);
            _context.SaveChanges();

            return getFinishObject = new Answer<MemberGetDto>(201, "Member created.", null);

        }


        [HttpGet]
        [Route("{fin}")]
        public ActionResult<Answer<MemberGetDto>> Get(string fin)
        {
            // burda yoxluyassan gelen tokenden ki bu tokenin fini ile burda gelen fin eynidise cavab qaytarassan
            Employee employee = _context.Employees.FirstOrDefault(a => a.fin == fin);

            if (employee == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "Employee not found.", null);
            }

            List<DBEmployee> dbEmployees = _context.dBEmployees.Where(a => a.employeeId == employee.id).ToList();

            if (dbEmployees.Count <= 0 && dbEmployees == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "DbEmployees not found.", null);
            }

            List<FamilyMembers> familyMembers = _context.FamilyMembers.Where(x => x.fin == employee.fin && x.dbId == dbEmployees.FirstOrDefault().databaseId).ToList();
            List<MemberGetDto> members = new List<MemberGetDto>();
            foreach (var item in familyMembers)
            {
                MemberGetDto memberGetDto = new MemberGetDto()
                {
                    dob = item.dob,
                    fullName = item.fullName,
                    relative = item.relative
                };
                members.Add(memberGetDto);
            }

            return getFinishObject = new Answer<MemberGetDto>(200, "Family member founded", members);

        }


    }
}


