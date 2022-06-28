using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.CardDtos;
using TimeSheet.Entities;
using VoltekApi.Helper;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]



    public class cardController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mp;
        Answer<CardGetDto> getFinishedObject;
        public cardController(DataContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        [HttpPost]
        public ActionResult<Answer<CardGetDto>> CreateCard(CardPostDto cardPostDto)
        {
            
            Employee employee = _db.Employees.FirstOrDefault(x => x.fin.ToLower() == cardPostDto.fin.ToLower());
            if (employee == null)
            {
                Employee newEmployee = new Employee()
                {
                    fin = cardPostDto.fin,
                    password = Hashing.ToSHA256(cardPostDto.fin)
                };
                _db.Employees.Add(newEmployee);
                _db.SaveChanges();
            }

            employee = _db.Employees.FirstOrDefault(x => x.fin.ToLower() == cardPostDto.fin.ToLower());

            List<DbEmployee> dbEmployees = _db.DbEmployees.Where(x => x.employeeId == employee.id).ToList();

            if (dbEmployees.Count >= 0)
            {
                Card newCard = _mp.Map<Card>(cardPostDto);

                _db.IdentityCards.Add(newCard);
                _db.SaveChanges();
            }
            else
            {
                foreach (var employeeCard in dbEmployees)
                {
                    employeeCard.isActive = false;
                }
                Card newCard = _mp.Map<Card>(cardPostDto);
               
                _db.IdentityCards.Add(newCard);
                _db.SaveChanges();
            }
            return getFinishedObject = new Answer<CardGetDto>(201, "Identity card created", null);
        }
    }
}
