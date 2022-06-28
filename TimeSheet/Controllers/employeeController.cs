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
    public class employeeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<EmployeeGetDto> getFinishObject;
        public employeeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        //public ActionResult<Answer<EmployeeGetDto>> GetAll()
        //{
        //    List<Employee> employees = _context.Employees.Where(x => x.isDeleted == false).ToList();
        //    if (employees.Count > 0)
        //    {
        //        List<EmployeeGetDto> UserGetList = employees.Select(x => new EmployeeGetDto() { fin = x.fin, dbCode = x.dbCode, photo = x.photo, seriya = x.seriya, adress = x.adress, email = x.email, date = x.date, expireDate = x.expireDate, firstName = x.firstName, issiedBy = x.issiedBy, number = x.number, lastName = x.lastName, phone1 = x.phone1, phone2 = x.phone2, phone3 = x.phone3, phone4 = x.phone4 }).ToList();

        //        return getFinishObject = new Answer<EmployeeGetDto>(200, "Employee founded", UserGetList);
        //    }
        //    else
        //    {
        //        return getFinishObject = new Answer<EmployeeGetDto>(400, "Employee not found", null);
        //    }
        //}

        [HttpGet("{code}")]
        public ActionResult<Answer<EmployeeGetDto>> Get(string code)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);

            if (employee != null)
            {
                return getFinishObject = new Answer<EmployeeGetDto>(200, "Employee founded", new List<EmployeeGetDto> { _mapper.Map<EmployeeGetDto>(employee) });
            }
            else
            {
                return getFinishObject = new Answer<EmployeeGetDto>(400, "Employee not found", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<EmployeeGetDto>> CreateEmployee(EmployeePostDto UserPostDto)
        {
            User user = _context.Users.FirstOrDefault(x => x.fin.ToLower() == UserPostDto.fin.ToLower());

            if (user == null)
            {
                return getFinishObject = new Answer<EmployeeGetDto>(400, "User not found", null);
            }

            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == UserPostDto.dbCode.ToLower());

            if (database == null)
            {
                return getFinishObject = new Answer<EmployeeGetDto>(400, "Database not found ", null);
            }

            User newUser = new User()
            {
                 fin = UserPostDto.fin
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            User currentUser = _context.Users.FirstOrDefault(x=>x.fin.ToLower() == UserPostDto.fin.ToLower());

            Card newCard = new Card()
            {
                address = UserPostDto.adress,
                date = UserPostDto.date,
                expireTime = UserPostDto.expireDate,
                firstName = UserPostDto.firstName,
                lastName = UserPostDto.lastName,
                number = UserPostDto.number,
                issiedBy = UserPostDto.issiedBy,
                series = UserPostDto.seriya,
                employeeId = currentUser.id
            };
            _context.IdentityCards.Add(newCard);
            _context.SaveChanges();

            Contact newContact = new Contact()
            {
                fin = UserPostDto.fin,
                dbCode = database.code,
                phone1 = UserPostDto.phone1,
                phone2 = UserPostDto.phone2,
                phone3 = UserPostDto.phone3,
                phone4 = UserPostDto.phone4,
                email = UserPostDto.email,
            };
            _context.Contacts.Add(newContact);
            _context.SaveChanges();

            return getFinishObject = new Answer<EmployeeGetDto>(201, "Employees created", null);

        }

        //[HttpPut]
        //public ActionResult<Answer<EmployeeGetDto>> UpdateUser(EmployeeUpdateDto UserUpdateDto)
        //{
        //    Employee employee = _context.Employees.FirstOrDefault(x => x.code.ToLower() == UserUpdateDto.code.ToLower() && x.isDeleted == false);

        //    if (employee == null)
        //    {
        //        return getFinishObject = new Answer<EmployeeGetDto>(400, "Employee not found", null);
        //    }

        //    employee.fin = UserUpdateDto.fin;

        //    _context.SaveChanges();

        //    return getFinishObject = new Answer<EmployeeGetDto>(204, "Employee updated", null);
        //}

        [HttpDelete]
        public ActionResult<Answer<EmployeeGetDto>> DeletedUser(string code)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);
            if (employee == null)
            {
                return getFinishObject = new Answer<EmployeeGetDto>(400, "Employee not found", null);
            }
            employee.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<EmployeeGetDto>(204, "Employee deleted", null);
        }

        [HttpPost]
        [Route("changePass")]
        public ActionResult<Answer<EmployeeGetDto>> ChangePassword(PasswordChangeDto ChangeDto)
        {
            User employee = _context.Users.FirstOrDefault(x => x.code.ToLower() == ChangeDto.code.ToLower() && x.isDeleted == false);

            if (employee == null)
            {
                return getFinishObject = new Answer<EmployeeGetDto>(400, "Employee not found", null);
            }
            if (ChangeDto.NewPassword != ChangeDto.ConfirmPassword)
            {
                return getFinishObject = new Answer<EmployeeGetDto>(409, "Password and ConfirmPassword isn't match", null);
            }
            employee = Hashing.ToSHA256(ChangeDto.NewPassword);

            _context.SaveChanges();

            return getFinishObject = new Answer<EmployeeGetDto>(204, "Password changed", null);
        }



    }
}
