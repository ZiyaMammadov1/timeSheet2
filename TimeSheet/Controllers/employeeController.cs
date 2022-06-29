using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.EmployeeInfoDtos;
using TimeSheet.Entities;
using VoltekApi.Helper;

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
                newUser.password = Hashing.ToSHA256(EmployeeInfoPostDto.password).ToString();
                _context.Employees.Add(newUser);
                _context.SaveChanges();

                user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == EmployeeInfoPostDto.fin.ToLower());
            }


            IdentityCard card = _context.IdentityCards.FirstOrDefault(x => x.employeeId == user.id && x.databaseId == database.id);

            if (card != null)
            {
                List<IdentityCard> cards = _context.IdentityCards.Where(x => x.employeeId == user.id && x.databaseId == database.id).ToList();
                foreach (var item in cards)
                {
                    item.isActive = false;
                }
                _context.SaveChanges();
            }

            if (card == null || EmployeeInfoPostDto.date != card.date)
            {
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
                    employeeId = user.id,
                    databaseId = database.id,
                    photo = EmployeeInfoPostDto.photo
                };

                _context.IdentityCards.Add(newCard);

            }


            Contact contact = _context.Contacts.FirstOrDefault(x => x.fin == user.fin && x.dbCode == database.code);

            if (contact == null)
            {
                Contact newContact = new Contact()
                {
                    fin = EmployeeInfoPostDto.fin,
                    dbCode = database.code,
                    phone1 = EmployeeInfoPostDto.phone1,
                    phone2 = EmployeeInfoPostDto.phone2,
                    phone3 = EmployeeInfoPostDto.phone3,
                    phone4 = EmployeeInfoPostDto.phone4,
                    email = EmployeeInfoPostDto.email
                };
                _context.Contacts.Add(newContact);

            }
            else
            {
                contact.fin = EmployeeInfoPostDto.fin;
                contact.phone1 = EmployeeInfoPostDto.phone1;
                contact.phone2 = EmployeeInfoPostDto.phone2;
                contact.phone3 = EmployeeInfoPostDto.phone3;
                contact.phone4 = EmployeeInfoPostDto.phone4;
                contact.email = EmployeeInfoPostDto.email;
            }


            _context.SaveChanges();

            return getFinishObject = new Answer<string>(201, "Employee created", null);

        }
    }
}
