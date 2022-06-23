using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.UserDto;
using TimeSheet.Entities;
using TimeSheet.SecondDtos.UserDtos;
using VoltekApi.Helper;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [EnableCors("AllowOrigin")]
    public class userController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<UserGetDto> getFinishObject;
        public userController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<UserGetDto>> GetAll()
        {
            List<User> users = _context.Users.Where(x => x.isDeleted == false).ToList();

            List<UserGetDto> UserGetList = new List<UserGetDto>();
            foreach (var user in users)
            {
                UserGetList.Add(_mapper.Map<UserGetDto>(user));
            }

            if (users.Count > 0)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "Ok", UserGetList);
            }
            else
            {
                return getFinishObject = new Answer<UserGetDto>(400, "User is empty", null);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Answer<UserGetDto>> Get(string id)
        {
            var exist = _context.Users.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);

            if (exist != null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "Ok", new List<UserGetDto> { _mapper.Map<UserGetDto>(exist) });

            }
            else
            {
                return getFinishObject = new Answer<UserGetDto>(200, "User doesn't exist", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<UserGetDto>> CreateUser(UserPostDto UserPostDto)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.name.ToLower() == UserPostDto.position.ToLower());
            if (position == null)
            {
                Position newPosition = new Position()
                {
                    isDeleted = false,
                    uuid = Guid.NewGuid().ToString(),
                    name = UserPostDto.position
                };

                _context.Positions.Add(newPosition);
                _context.SaveChanges();
            }
            position = _context.Positions.FirstOrDefault(x => x.name.ToLower() == UserPostDto.position.ToLower());

            Department department = _context.Departments.FirstOrDefault(x => x.name == UserPostDto.department);
            if (department == null)
            {
                Department newDepartment = new Department()
                {
                    isDeleted = false,
                    uuid = Guid.NewGuid().ToString(),
                    name = UserPostDto.position
                };

                _context.Departments.Add(newDepartment);
                _context.SaveChanges();
            }
            department = _context.Departments.FirstOrDefault(x => x.name == UserPostDto.department);


            User newUser = new User()
            {
                uuid = Guid.NewGuid().ToString(),
                cid = UserPostDto.cid,
                email = UserPostDto.email,
                fin = UserPostDto.fin.ToLower(),
                firstName = UserPostDto.firstName,
                lastName = UserPostDto.lastName,
                fullName = UserPostDto.firstName + " " + UserPostDto.lastName,
                Password = Hashing.ToSHA256(UserPostDto.password),
                positionId = position.id,
                isDeleted = false,
                photo = UserPostDto.photo,
                createdTime = DateTime.UtcNow,
                departmentId = department.id,
                dateOfBirthday = UserPostDto.dateOfBirthday,
                age = DateTime.UtcNow.Year - UserPostDto.dateOfBirthday.Year,
                phone1 = UserPostDto.phone1,
                phone2 = UserPostDto.phone2,
                phone3 = UserPostDto.phone3,
                phone4 = UserPostDto.phone4
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return getFinishObject = new Answer<UserGetDto>(201, "User created", null);
        }

        [HttpPost]
        [Route("addlist")]
        public ActionResult<Answer<UserGetDto>> CreateUserFromList(List<SecondUserPostDto> users)
        {
            List<User> UserList = new List<User>();
            //List<int> userIds = new List<int>();

            foreach (var user in users)
            {
                Position position = _context.Positions.FirstOrDefault(x => x.name.ToLower() == user.position.ToLower());

                if (position == null)
                {
                    Position newPosition = new Position()
                    {
                        name = user.position,
                        isDeleted = false,
                        uuid = Guid.NewGuid().ToString()
                    };

                    _context.Positions.Add(newPosition);
                    _context.SaveChanges();

                    position = _context.Positions.FirstOrDefault(x => x.name == newPosition.name);

                }

                Department department = _context.Departments.FirstOrDefault(x => x.name.ToLower() == user.department.ToLower());

                if (department == null)
                {
                    Department newDepartment = new Department()
                    {
                        name = user.department,
                        isDeleted = false,
                        uuid = Guid.NewGuid().ToString()
                    };

                    _context.Departments.Add(newDepartment);
                    _context.SaveChanges();

                    department = _context.Departments.FirstOrDefault(x => x.name == newDepartment.name);

                }

                User newUser = new User()
                {
                    uuid = Guid.NewGuid().ToString(),
                    cid = user.cid,
                    email = user.email,
                    fin = user.fin.ToLower(),
                    firstName = user.firstName,
                    lastName = user.lastName,
                    photo = user.photo,
                    Password = Hashing.ToSHA256(user.fin.ToLower()),
                    fullName = user.firstName + " " + user.lastName,
                    positionId = position.id,
                    isDeleted = false,
                    createdTime = DateTime.UtcNow,
                    departmentId = department.id,
                    age = DateTime.UtcNow.Year - user.dateOfBirthday.Year,
                    phone1 = user.phone1,
                    phone2 = user.phone2,
                    phone3 = user.phone3,
                    phone4 = user.phone4
                };

                if (newUser.fin != null)
                {
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    User currentUser = _context.Users.FirstOrDefault(x => x.fin == user.fin);

                    if (user.FamilyMembers.Count() > 0)
                    {
                        foreach (var member in user.FamilyMembers)
                        {

                            FamilyMembers familymember = new FamilyMembers()
                            {
                                member = member.member,
                                memberAge = member.memberAge,
                                memberDoB = member.memberDoB,
                                memberFullName = member.memberFullname,
                                userId = currentUser.id
                            };

                        _context.FamilyMembers.Add(familymember);
                        }
                        _context.SaveChanges();
                    }

                }
                else
                {
                    getFinishObject = new Answer<UserGetDto>(200, "Users fin is empty", null);
                }






            }

            //_context.Users.AddRange(UserList);
            //userIds.AddRange(UserList.Select(x=>x.id));
            //_context.SaveChanges();


            //foreach (var user in users)
            //{
            //    foreach (var member in user.FamilyMembers)
            //    {
            //        FamilyMembers familymember = new FamilyMembers()
            //        {
            //            member = member.member,
            //            memberAge = member.memberAge,
            //            memberDoB = member.memberDoB,
            //            memberFullName = member.memberFullname,
            //            userId = user.id
            //        };
            //    }
            //}


            return getFinishObject = new Answer<UserGetDto>(201, "Users created", null);

        }

        [HttpPut]
        public ActionResult<Answer<UserGetDto>> UpdateUser(UserUpdateDto UserUpdateDto)
        {
            var exist = _context.Users.FirstOrDefault(x => x.uuid == UserUpdateDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "User not found", null);
            }
            var position = _context.Positions.FirstOrDefault(x => x.id == UserUpdateDto.positionId);

            if (position == null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "Position id is not correct", null);
            }

            exist.cid = UserUpdateDto.cid;
            exist.fin = UserUpdateDto.fin;
            exist.email = UserUpdateDto.email;
            exist.firstName = UserUpdateDto.firstName;
            exist.lastName = UserUpdateDto.lastName;
            exist.positionId = UserUpdateDto.positionId;
            exist.fullName = UserUpdateDto.firstName + " " + UserUpdateDto.lastName;
            exist.phone1 = UserUpdateDto.phone1;
            exist.phone2 = UserUpdateDto.phone2;
            exist.phone3 = UserUpdateDto.phone3;
            exist.phone4 = UserUpdateDto.phone4;

            _context.SaveChanges();

            return getFinishObject = new Answer<UserGetDto>(204, "No Content", null);
        }

        [HttpDelete("{id}")]
        public ActionResult<Answer<UserGetDto>> DeletedUser(string id)
        {
            var exist = _context.Users.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);
            if (exist == null)
            {
                return getFinishObject = new Answer<UserGetDto>(400, "User not found", null);
            }
            exist.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<UserGetDto>(204, "No Content", null);
        }

        [HttpPost()]
        [Route("changePass")]
        public ActionResult<Answer<UserGetDto>> ChangePassword(PasswordChangeDto ChangeDto)
        {
            var exist = _context.Users.FirstOrDefault(x => x.id == ChangeDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<UserGetDto>(400, "User not found", null);
            }
            if (ChangeDto.NewPassword != ChangeDto.ConfirmPassword)
            {
                return getFinishObject = new Answer<UserGetDto>(409, "Password and ConfirmPassword isn't match", null);
            }
            exist.Password = Hashing.ToSHA256(ChangeDto.NewPassword);

            _context.SaveChanges();

            return getFinishObject = new Answer<UserGetDto>(204, "Password changed", null);
        }


    }
}
