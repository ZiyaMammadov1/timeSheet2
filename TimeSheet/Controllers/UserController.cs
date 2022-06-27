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
            List<Employee> employees = _context.Employees.Where(x => x.isDeleted == false).ToList();
            if (employees.Count > 0)
            {
                List<UserGetDto> UserGetList = employees.Select(x => new UserGetDto() { fin = x.fin, uuid = x.uuid }).ToList();

                return getFinishObject = new Answer<UserGetDto>(200, "Employee founded", UserGetList);
            }
            else
            {
                return getFinishObject = new Answer<UserGetDto>(400, "Employee not found", null);
            }
        }

        [HttpGet("{code}")]
        public ActionResult<Answer<UserGetDto>> Get(string code)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);

            if (employee != null)
            {
                return getFinishObject = new Answer<UserGetDto>(200, "Employee founded", new List<UserGetDto> { _mapper.Map<UserGetDto>(employee) });
            }
            else
            {
                return getFinishObject = new Answer<UserGetDto>(400, "Employee not found", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<UserGetDto>> CreateEmployee(UserPostDto UserPostDto)
        {
            Employee employee = new Employee() {code = UserPostDto.code,fin = UserPostDto.fin,password = Hashing.ToSHA256(UserPostDto.fin).ToString() };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return getFinishObject = new Answer<UserGetDto>(201, "Employee created", null);
        }

        [HttpPut]
        public ActionResult<Answer<UserGetDto>> UpdateUser(UserUpdateDto UserUpdateDto)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.code.ToLower() == UserUpdateDto.code.ToLower() && x.isDeleted == false);

            if (employee == null)
            {
                return getFinishObject = new Answer<UserGetDto>(400, "Employee not found", null);
            }
           
            employee.fin = UserUpdateDto.fin;

            _context.SaveChanges();

            return getFinishObject = new Answer<UserGetDto>(204, "Employee updated", null);
        }

        [HttpDelete]
        public ActionResult<Answer<UserGetDto>> DeletedUser(string code)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);
            if (employee == null)
            {
                return getFinishObject = new Answer<UserGetDto>(400, "Employee not found", null);
            }
            employee.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<UserGetDto>(204, "Employee deleted", null);
        }

        [HttpPost]
        [Route("changePass")]
        public ActionResult<Answer<UserGetDto>> ChangePassword(PasswordChangeDto ChangeDto)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.code.ToLower() == ChangeDto.code.ToLower() && x.isDeleted == false);

            if (employee == null)
            {
                return getFinishObject = new Answer<UserGetDto>(400, "Employee not found", null);
            }
            if (ChangeDto.NewPassword != ChangeDto.ConfirmPassword)
            {
                return getFinishObject = new Answer<UserGetDto>(409, "Password and ConfirmPassword isn't match", null);
            }
            employee.password = Hashing.ToSHA256(ChangeDto.NewPassword);

            _context.SaveChanges();

            return getFinishObject = new Answer<UserGetDto>(204, "Password changed", null);
        }





    }
}
