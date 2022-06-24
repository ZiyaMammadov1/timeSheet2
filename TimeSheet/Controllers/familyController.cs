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
        public ActionResult <Answer<MemberGetDto>> CreateMember(MemberPostDto memberPostDto)
        {
            User user = _context.Users.FirstOrDefault(a=>a.fin.ToLower() == memberPostDto.fin.ToLower());
            if(user == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400,"User not found.",null);
            }

            FamilyMembers newMember = new FamilyMembers()
            {
                member = memberPostDto.member,
                memberAge = memberPostDto.memberAge,
                memberDoB = memberPostDto.memberDoB,
                memberFullName = memberPostDto.memberFullname,
                userId = user.id
            };

            _context.FamilyMembers.Add(newMember);
            _context.SaveChanges();

            return getFinishObject = new Answer<MemberGetDto>(201, "Member created.", null);

        }


        [HttpDelete]
        public ActionResult<Answer<MemberGetDto>> DeleteMember(string fin)
        {
            User user = _context.Users.FirstOrDefault(x => x.fin.ToLower() == fin.ToLower());

            if (user == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400, "User not found.", null);
            }

            List<FamilyMembers> UsersFamily = _context.FamilyMembers.Where(x=>x.userId == user.id).ToList();
            _context.FamilyMembers.RemoveRange(UsersFamily);
            _context.SaveChanges();

            return getFinishObject = new Answer<MemberGetDto>(204, "User family members deleted.", null);

        }


        [HttpPost]
        [Route("addlist")]
        public ActionResult<Answer<MemberGetDto>> CreateFamilies(List<MemberPostDto> memberPostDtos)
        {
            List<FamilyMembers> addedMember = new List<FamilyMembers>();
            List<MemberPostDto> notFoundUserMembers = new List<MemberPostDto>();
            Answer<MemberGetDto> getFinishObjectWithPost;

            foreach (var memberPostDto in memberPostDtos)
            {
                User user = _context.Users.FirstOrDefault(a => a.fin.ToLower() == memberPostDto.fin.ToLower());
                if (user == null)
                {
                    notFoundUserMembers.Add(memberPostDto);
                }
                else 
                { 
                    FamilyMembers newMember = new FamilyMembers()
                    {
                        member = memberPostDto.member,
                        memberAge = memberPostDto.memberAge,
                        memberDoB = memberPostDto.memberDoB,
                        memberFullName = memberPostDto.memberFullname,
                        userId = user.id
                    };

                    addedMember.Add(newMember);
                }
            }
            _context.FamilyMembers.AddRange(addedMember);
            _context.SaveChanges();

            return getFinishObjectWithPost = new Answer<MemberGetDto>(201, "Families created. Who are not found User", _mapper.Map<List<MemberGetDto>>(notFoundUserMembers));

        }


        [HttpGet]
        public ActionResult<Answer<MemberGetDto>> GetUserFamily(string fin)
        {
            User user = _context.Users.FirstOrDefault(x=>x.fin.ToLower() == fin.ToLower());

            if(user == null)
            {
                return getFinishObject = new Answer<MemberGetDto>(400,"User not found", null);
            }
            else
            {
                List<FamilyMembers> UserFamily = _context.FamilyMembers.Where(a=>a.userId == user.id).ToList();
                List<MemberGetDto> UserFamilyGet = new List<MemberGetDto>();

                if (UserFamily.Count > 0)
                {
                    foreach (var member in UserFamily)
                    {
                        MemberGetDto memberGet = new MemberGetDto()
                        {
                            member = member.member,
                            memberAge = member.memberAge,
                            memberDoB = member.memberDoB,
                            memberFullname = member.memberFullName
                        };
                        UserFamilyGet.Add(memberGet);
                    }
                    return getFinishObject = new Answer<MemberGetDto>(200, "User family is empty", UserFamilyGet);
                }
                else
                {
                    return getFinishObject = new Answer<MemberGetDto>(200, "User family is empty", null);
                }
            }
        }
    }
}


