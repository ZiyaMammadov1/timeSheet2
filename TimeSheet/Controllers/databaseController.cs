using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.DatabaseDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class databaseController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mp;
        Answer<DatabaseGetDto> getFinishedObject;
        public databaseController(DataContext db, IMapper mp)
        {
            _db  = db;
            _mp = mp;
        }

        [HttpPost]
        public ActionResult<Answer<DatabaseGetDto>> CreateDatabase(DatabasePostDto DatabasePostDto)
        {
            Database database = _mp.Map<Database>(DatabasePostDto);
            _db.Database.Add(database);
            _db.SaveChanges();
            return getFinishedObject = new Answer<DatabaseGetDto>(201,"Database created", null);
        }
    }
}
