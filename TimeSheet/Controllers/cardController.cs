using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.CardDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cardController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<string> getFinishObject;
        public cardController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Answer<string>> AddCard(CardPostDto CardPostDto)
        {
            Employee user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == CardPostDto.fin.ToLower());
            if (user == null)
            {
                return getFinishObject = new Answer<string>(400,"User not found", null);
            }

            Employee newUser = new Employee();

            if (user == null)
            {
                newUser.fin = EmployeeInfoPostDto.fin;
                _context.Employees.Add(newUser);
                _context.SaveChanges();
            }

            #region card
            //IdentityCard card = _context.IdentityCards.FirstOrDefault(x => x.employeeId == user.id && x.databaseId == database.id);

            //if (card != null)
            //{
            //    List<IdentityCard> cards = _context.IdentityCards.Where(x => x.employeeId == user.id && x.databaseId == database.id).ToList();
            //    foreach (var item in cards)
            //    {
            //        item.isActive = false;
            //    }
            //    _context.SaveChanges();
            //}

            //if (card == null || EmployeeInfoPostDto.date != card.date)
            //{
            //    IdentityCard newCard = new IdentityCard()
            //    {
            //        address = EmployeeInfoPostDto.adress,
            //        date = EmployeeInfoPostDto.date,
            //        expireTime = EmployeeInfoPostDto.expireDate,
            //        firstName = EmployeeInfoPostDto.firstName,
            //        lastName = EmployeeInfoPostDto.lastName,
            //        number = EmployeeInfoPostDto.number,
            //        issiedBy = EmployeeInfoPostDto.issiedBy,
            //        series = EmployeeInfoPostDto.seriya,
            //        employeeId = user.id,
            //        databaseId = database.id,
            //        photo = EmployeeInfoPostDto.photo
            //    };

            //    _context.IdentityCards.Add(newCard);

            //}
            #endregion

            #region contact
            ////Contact contact = _context.Contacts.FirstOrDefault(x => x.fin == user.fin && x.dbCode == database.code);

            ////if (contact == null)
            ////{
            ////    Contact newContact = new Contact()
            ////    {
            ////        fin = EmployeeInfoPostDto.fin,
            ////        dbCode = database.code,
            ////        phone1 = EmployeeInfoPostDto.phone1,
            ////        phone2 = EmployeeInfoPostDto.phone2,
            ////        phone3 = EmployeeInfoPostDto.phone3,
            ////        phone4 = EmployeeInfoPostDto.phone4,
            ////        email = EmployeeInfoPostDto.email
            ////    };
            ////    _context.Contacts.Add(newContact);

            ////}
            ////else
            ////{
            ////    contact.fin = EmployeeInfoPostDto.fin;
            ////    contact.phone1 = EmployeeInfoPostDto.phone1;
            ////    contact.phone2 = EmployeeInfoPostDto.phone2;
            ////    contact.phone3 = EmployeeInfoPostDto.phone3;
            ////    contact.phone4 = EmployeeInfoPostDto.phone4;
            ////    contact.email = EmployeeInfoPostDto.email;
            ////}


            //_context.SaveChanges();
            #endregion

            return getFinishObject = new Answer<string>(201, "Employee created", null);

        }



    }
}
