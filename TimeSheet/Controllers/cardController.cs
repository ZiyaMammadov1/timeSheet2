using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            Database db = _context.Database.FirstOrDefault(x => x.code.ToLower() == CardPostDto.dbCode.ToLower());
            if (db == null)
            {
                return getFinishObject = new Answer<string>(400, "User not found", null);
            }


            IdentityCard card = _context.IdentityCards.FirstOrDefault(x => x.employeeId == user.id && x.databaseId == db.id);

            if (card != null)
            {
                List<IdentityCard> cards = _context.IdentityCards.Where(x => x.employeeId == user.id && x.databaseId == db.id).ToList();
                foreach (var item in cards)
                {
                    item.isActive = false;
                }
                _context.SaveChanges();
            }

            if (card == null || CardPostDto.date != card.date)
            {
                IdentityCard newCard = new IdentityCard()
                {
                    address = CardPostDto.adress,
                    date = CardPostDto.date,
                    expireTime = CardPostDto.expireDate,
                    firstName = CardPostDto.firstName,
                    lastName = CardPostDto.lastName,
                    number = CardPostDto.number,
                    issiedBy = CardPostDto.issiedBy,
                    series = CardPostDto.seriya,
                    employeeId = user.id,
                    databaseId = db.id,
                    photo = CardPostDto.photo
                };

                _context.IdentityCards.Add(newCard);
                _context.SaveChanges();

            }


            return getFinishObject = new Answer<string>(201, "Employee created", null);

        }



    }
}
