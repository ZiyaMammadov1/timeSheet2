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


        [HttpPost]
        public ActionResult<Answer<MemberGetDto>> CreateMember(MemberPostDto memberPostDto)
        {
            User user = _context.Employees.FirstOrDefault(a => a.fin.ToLower() == memberPostDto.fin.ToLower());
            if (user == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "User not found.", null);
            }

            FamilyMembers newMember = new FamilyMembers()
            {
                member = memberPostDto.member,
                age = memberPostDto.memberAge,
                dob = memberPostDto.memberDoB,
                fullName = memberPostDto.memberFullname,
                userId = user.id
            };

            _context.FamilyMembers.Add(newMember);
            _context.SaveChanges();

            return getFinishObject = new Answer<MemberGetDto>(201, "Member created.", null);

        }


        [HttpDelete]
        public ActionResult<Answer<MemberGetDto>> DeleteMember(string fin)
        {
            User user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == fin.ToLower());

            if (user == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "User not found.", null);
            }

            List<FamilyMembers> UsersFamily = _context.FamilyMembers.Where(x => x.userId == user.id).ToList();
            _context.FamilyMembers.RemoveRange(UsersFamily);
            _context.SaveChanges();

            return getFinishObject = new Answer<MemberGetDto>(204, "User family members deleted.", null);

        }


        [HttpGet]
        public ActionResult<Answer<MemberGetDto>> GetUserFamily(string fin)
        {
            if (fin == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "Fin is empty", null);
            }
            User user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == fin.ToLower());

            if (user == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "User not found", null);
            }
            else
            {
                List<FamilyMembers> UserFamily = _context.FamilyMembers.Where(a => a.userId == user.id).ToList();
                List<MemberGetDto> UserFamilyGet = new List<MemberGetDto>();

                if (UserFamily.Count > 0)
                {
                    foreach (var member in UserFamily)
                    {
                        MemberGetDto memberGet = new MemberGetDto()
                        {
                            member = member.member,
                            memberAge = member.age,
                            memberDoB = member.dob,
                            memberFullname = member.fullName
                        };
                        UserFamilyGet.Add(memberGet);
                    }
                    return getFinishObject = new Answer<MemberGetDto>(200, "User family is empty", UserFamilyGet);
                }
                else
                {
                    return getFinishObject = new Answer<MemberGetDto>(200, "User families found", null);
                }
            }
        }
    }
}


