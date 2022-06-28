using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.EmployeeInfoDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<string> getFinishObject;
        public employeeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Answer<string>> AddEmployeeInfo(EmployeeInfoPostDto EmployeeInfoPostDto)
        {
            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == EmployeeInfoPostDto.dbCode.ToLower());
            if (database == null)
            {
                return getFinishObject = new Answer<string>(400, "Database not found ", null);
            }

            Employee user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == EmployeeInfoPostDto.fin.ToLower());

            Employee newUser = new Employee();

            if (user == null)
            {
                newUser.fin = EmployeeInfoPostDto.fin;
                _context.Employees.Add(newUser);
                _context.SaveChanges();

             user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == EmployeeInfoPostDto.fin.ToLower());
            }

            if(user == null)
            {
                return getFinishObject = new Answer<string>(400, "User not found ", null);

            }



            //IdentityCard card = _context.IdentityCards.FirstOrDefault(x => x.employeeId == user.id && x.);


            IdentityCard newCard = new IdentityCard()
            {
                address = EmployeeInfoPostDto.adress,
                date = EmployeeInfoPostDto.date,
                expireTime = EmployeeInfoPostDto.expireDate,
                firstName = EmployeeInfoPostDto.firstName,
                lastName = EmployeeInfoPostDto.lastName,
                number = EmployeeInfoPostDto.number,
                issiedBy = EmployeeInfoPostDto.issiedBy,
                series = EmployeeInfoPostDto.seriya,
                employeeId = user.id
            };
            _context.IdentityCards.Add(newCard);
            _context.SaveChanges();

            Contact newContact = new Contact()
            {
                fin = EmployeeInfoPostDto.fin,
                dbCode = database.code,
                phone1 = EmployeeInfoPostDto.phone1,
                phone2 = EmployeeInfoPostDto.phone2,
                phone3 = EmployeeInfoPostDto.phone3,
                phone4 = EmployeeInfoPostDto.phone4,
                email = EmployeeInfoPostDto.email,
            };
            _context.Contacts.Add(newContact);
            _context.SaveChanges();

            return getFinishObject = new Answer<string>(201, "Employees created", null);






        }
    }
}
