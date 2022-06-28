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
        public cardController(DataContext db)
        {
            _db = db;
        }
        public ActionResult CreateCard(CardPostDto cardPostDto)
        {
            Employee employee = _db.Employees.FirstOrDefault(x=>x.fin.ToLower()==cardPostDto.fin.ToLower());
            if(employee == null)
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

            DbEmployee dbEmployees = _db.DbEmployees.FirstOrDefault(x=>x.employeeId == employee.id);

            if(dbEmployees == null)
            {
                Card newCard = new Card ()
                {
                    series = cardPostDto.series,
                    number = cardPostDto.number,
                    lastName = cardPostDto.lastName,
                    firstName = cardPostDto.firstName,
                    address = cardPostDto.address,
                    code = cardPostDto.code,
                    date = cardPostDto.date,
                    expireTime = cardPostDto.expireTime,
                    issiedBy = cardPostDto.issiedBy,
                    employeeId = employee.id
                };
                _db.IdentityCards.Add(newCard);
                _db.SaveChanges();



                //DbEmployee newEmployee = new DbEmployee() {employeeId = employee.id};
            }
            return Ok("asd");
        }
    }
}
