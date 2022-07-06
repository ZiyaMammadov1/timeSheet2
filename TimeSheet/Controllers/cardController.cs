using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.CardDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class cardController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<CardGetDto> getFinishObject;
        public cardController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Answer<CardGetDto>> AddCard(CardPostDto CardPostDto)
        {
            Employee user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == CardPostDto.fin.ToLower());
            if (user == null)
            {
                return getFinishObject = new Answer<CardGetDto>(400, "User not found", null);
            }
            Database db = _context.Database.FirstOrDefault(x => x.code.ToLower() == CardPostDto.dbCode.ToLower());
            if (db == null)
            {
                return getFinishObject = new Answer<CardGetDto>(400, "Database not found", null);
            }
              


            List<IdentityCard> cards = _context.IdentityCards.Where(x => x.employeeId == user.id).ToList();

            IdentityCard card = cards.FirstOrDefault(x=>x.databaseId == db.id && x.series == CardPostDto.seriya);

           if(card != null)
           {
                card.photo = CardPostDto.photo;
                card.address = CardPostDto.adress;
                card.firstName = CardPostDto.firstName;
                card.lastName = CardPostDto.lastName;
                card.expireTime = CardPostDto.expireDate;
                card.number = CardPostDto.number;
                card.issiedBy = CardPostDto.issiedBy;
                _context.SaveChanges();
                return getFinishObject = new Answer<CardGetDto>(200, $"Card updated {user.fin}", null);
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


            return getFinishObject = new Answer<CardGetDto>(201, "Employee created", null);

        }


        [HttpGet]
        [Route("{fin}")]
        public ActionResult<Answer<CardGetDto>> Get(string fin, Guid? uuid)
        {

            // burda yoxluyassan gelen tokenden ki bu tokenin fini ile burda gelen fin eynidise cavab qaytarassan
            Employee employee = _context.Employees.FirstOrDefault(a => a.fin == fin && a.isDeleted == false);

            if (employee == null)
            {
                return getFinishObject = new Answer<CardGetDto>(400, "Employee not found.", null);
            }

            List<DBEmployee> dbEmployees = _context.dBEmployees.Include(x=>x.Company).Where(a => a.employeeId == employee.id).ToList();

            if (dbEmployees == null || dbEmployees.Count <= 0)
            {
                return getFinishObject = new Answer<CardGetDto>(400, "DbEmployees not found.", null);
            }

            DBEmployee dBEmployee = dbEmployees.FirstOrDefault();
            int dbId;
            if(uuid != null)
            {
                dBEmployee = dbEmployees.FirstOrDefault(x => x.Company.uuid.ToLower() == uuid.ToString());
            }
            dbId = dBEmployee.databaseId;


            List<IdentityCard> identityCards = _context.IdentityCards.Where(x => x.employeeId == employee.id && x.databaseId == dbId).ToList();

            if(identityCards.Count == 0)
            {
                return getFinishObject = new Answer<CardGetDto>(400, "Card not found.", null);
            }
            List<CardGetDto> cardsGetDto = new List<CardGetDto>();
            foreach (var item in identityCards)
            {
                CardGetDto cardGetDto = new CardGetDto()
                {
                    fin = employee.fin,
                    adress = item.address,
                    date = item.date,
                    expireDate = item.expireTime,
                    firstName = item.firstName,
                    issiedBy = item.issiedBy,
                    lastName = item.lastName,
                    number = item.number,
                    photo = item.photo,
                    seriya = item.series,
                    isActive = item.isActive
                };
                cardsGetDto.Add(cardGetDto);
            }

            return getFinishObject = new Answer<CardGetDto>(200, "Employee cards founded", cardsGetDto);

        }

    }
}
