using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.CompanyDtos;
using TimeSheet.Dtos.DepartmentDtos;
using TimeSheet.Dtos.DtosForFront;
using TimeSheet.Dtos.EmployeeInfoDtos;
using TimeSheet.Dtos.LoginDtos;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Dtos.ProjectDtos;
using TimeSheet.Dtos.RefreshTokenDtos;
using TimeSheet.Dtos.TokenWithUserInfo;
using TimeSheet.Dtos.UserDto;
using TimeSheet.Entities;
using TimeSheet.Helper;
using VoltekApi.Helper;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]



    public class loginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        Answer<UserLoginDto> loginfinishObject;
        public loginController(DataContext context, IConfiguration config, IJwtService jwtService, IMapper mapper)
        {
            _context = context;
            _config = config;
            _jwtService = jwtService;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult<Answer<UserLoginDto>> Login(UserLoginDto userLoginDto)
        {

            TokenInit tokenInitilizing = new TokenInit(_jwtService, _context);
            if (userLoginDto.key == null)
            {
                return loginfinishObject = new Answer<UserLoginDto>(404, "Username empty", null);
            }
            Employee User = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == userLoginDto.key.ToLower());

            if (User == null)
            {
                return loginfinishObject = new Answer<UserLoginDto>(400, "FIN or password is incorrect", null);

            }
            if (User.password != Hashing.ToSHA256(userLoginDto.password))
            {

                return loginfinishObject = new Answer<UserLoginDto>(409, "FIN or password is incorrect", null);
            }
            UserLoginDto UserLoginDto = new UserLoginDto()
            {
                key = userLoginDto.key,
                password = userLoginDto.password
            };



            List<DBEmployee> EmployeeList = _context.dBEmployees.Include(x => x.Company)
                                                                .Include(x => x.Database)
                                                                .Include(x => x.Depament)
                                                                .Include(x => x.Employee)
                                                                .Include(x => x.Position)
                 .Where(x => x.employeeId == User.id).ToList();
            if (EmployeeList == null || EmployeeList.Count() <= 0)
            {
                return loginfinishObject = new Answer<UserLoginDto>(409, "You haven't permission to login", null);
            }

            DBEmployee dbEmployee = EmployeeList.FirstOrDefault();

            Token token = tokenInitilizing.Init(UserLoginDto, _config, User.id);


            token.User = _mapper.Map<UserGetDto>(User);

            IdentityCard card = _context.IdentityCards.FirstOrDefault(x => x.employeeId == User.id && x.isActive == true);

            if (card == null)
            {
                return loginfinishObject = new Answer<UserLoginDto>(400, "Cart not found", null);
            }
            var OrderForSalary = _context.Orders.FirstOrDefault(x => x.fin == User.fin && x.dbCode == EmployeeList.First().Database.code && x.isDeleted == false);

            Contact contact = _context.Contacts.FirstOrDefault(x => x.employeeId == User.id && x.dbId == EmployeeList.First().Database.id && x.isDeleted == false);

            if (contact == null)
            {
                return loginfinishObject = new Answer<UserLoginDto>(400, "Contact not found", null);
            }


            tokenInUserInfo userinfo = new tokenInUserInfo()
            {
                fin = User.fin,
                firstName = card.firstName,
                lastName = card.lastName,
                photo = card.photo,
                position = dbEmployee.Position.name,
                company = dbEmployee.Company.name,
                department = dbEmployee.Depament.name,
                salary = OrderForSalary.salaryTotal,
                email = contact.email
            };
            token.UserInfo = userinfo;


            return StatusCode(200, token);
        }


        [HttpPost]
        [Route("refreshToken")]
        public ActionResult<Answer<UserLoginDto>> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var token = _context.RefreshTokens.FirstOrDefault(x => x.RefreshTokenString == refreshTokenDto.refreshtoken);

            if (token == null)
                return loginfinishObject = new Answer<UserLoginDto>(200, "Refresh token not found. Sign in with user", null);

            var user = _context.Employees.FirstOrDefault(x => x.id == token.employeeId);

            if (user == null)
                return loginfinishObject = new Answer<UserLoginDto>(200, "User not found. Sign in another user", null);


            UserLoginDto item = new UserLoginDto()
            {
                key = user.fin,
                password = user.password
            };

            if (token.RefreshTokenEndDate > System.DateTime.Now)
            {
                Token Token = _jwtService.Generate(item, _config, _config.GetSection("JWT:secret").Value);

                token.RefreshTokenString = Token.RefreshToken;
                token.RefreshTokenEndDate = Token.ExpiredTime.AddMinutes(5);
                _context.SaveChanges();

                return Ok(new { token = Token });
            }
            else
            {
                return loginfinishObject = new Answer<UserLoginDto>(400, "Token is time out. Sign in with user", null);
            }

        }

        [HttpGet]
        [Route("workPlaces")]
        public ActionResult<Answer<CommonInfoDto>> GetAllWorkPlaces(string fin)
        {

            Answer<CommonInfoDto> companyfinishObject;

            Employee employee = _context.Employees.FirstOrDefault(x => x.fin == fin && x.isDeleted == false);

            if (employee == null)
            {
                return companyfinishObject = new Answer<CommonInfoDto>(400, "Employee not found", null);
            }

            List<DBEmployee> dbEmployees = _context.dBEmployees.Include(x=>x.Company).ThenInclude(x=>x.Database).Where(x => x.employeeId == employee.id && 
                                                                            x.isActive == true &&
                                                                            x.isDelete == false)
                                                                            .ToList();

            if (dbEmployees.Count <= 0)
            {
                return companyfinishObject = new Answer<CommonInfoDto>(400, "DbEmployees not found", null);
            }

            List<IdentityCard> IdentityCard = _context.IdentityCards.Where(x=>x.employeeId == employee.id).ToList();
            
            List<Contact> Contacts = _context.Contacts.Where(x=>x.employeeId == employee.id).ToList();

            List<Order> Orders = _context.Orders
                                            .Include(x=>x.Position)
                                            .Include(x=>x.Deprtment)
                                            .Include(x=>x.Project)
                                            .Include(x=>x.Company)
                                            .Where(x=>x.fin == employee.fin && x.orderType == "1").ToList();

            List<CommonInfoDto> companiesGetDto = new List<CommonInfoDto>();


            foreach (var item in dbEmployees)
            {
                IdentityCard card = IdentityCard.FirstOrDefault(x => x.employeeId == employee.id &&
                                                                   x.databaseId == item.databaseId &&
                                                                   x.isActive == true);
                
                Contact contact = Contacts.FirstOrDefault(x=>x.dbId == item.databaseId && x.isDeleted == false);

                Order order = Orders.Find(x=>x.id==item.OrderId);

                CommonInfoDto company = new CommonInfoDto()
                {
                    uuid = item.Company.uuid,
                    fin = employee.fin,
                    firstName = card.firstName,
                    lastName = card.lastName,
                    photo = card.photo,
                    email = contact.email,
                    salary = order.salaryTotal,
                    Project = _mapper.Map<ProjectGetDto>(order.Project),
                    Department = _mapper.Map<DepartmentGetDto>(order.Deprtment),
                    Position = _mapper.Map<PositionGetDto>(order.Position),
                    Company = _mapper.Map<CompanyGetDto>(order.Company),
                    dateTo = order.dateTo
                };
               
                companiesGetDto.Add(company);

            }


       

            return companyfinishObject = new Answer<CommonInfoDto>(200, "Companies founded", companiesGetDto);


        }

        
    }
}
