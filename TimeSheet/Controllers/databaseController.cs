using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            _db = db;
            _mp = mp;
        }

        [HttpPost]
        public ActionResult<Answer<DatabaseGetDto>> CreateDatabase(DatabasePostDto DatabasePostDto)
        {
            if (_db.Database.Any(x => x.name.ToLower() == DatabasePostDto.name.ToLower()))
            {
                return getFinishedObject = new Answer<DatabaseGetDto>(409, "This database existed", null);
            }
            Database database = _mp.Map<Database>(DatabasePostDto);
            _db.Database.Add(database);
            _db.SaveChanges();
            return getFinishedObject = new Answer<DatabaseGetDto>(201, "Database created", null);
        }

        [HttpGet("{code}")]
        public ActionResult<Answer<DatabaseGetDto>> GetDatabase(string code)
        {
            Database database = _db.Database.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);
            if (database == null)
            {
                return getFinishedObject = new Answer<DatabaseGetDto>(400, "Database not found", null);
            }
            return getFinishedObject = new Answer<DatabaseGetDto>(200, "Database founded", new List<DatabaseGetDto> { _mp.Map<DatabaseGetDto>(database) });

        }

        [HttpGet]
        public ActionResult<Answer<DatabaseGetDto>> GetAllDatabase()
        {
            List<Database> database = _db.Database.Where(x => x.isDeleted == false).ToList();
            if (database.Count <= 0)
            {
                return getFinishedObject = new Answer<DatabaseGetDto>(400, "Database items not found", null);
            }
            List<DatabaseGetDto> databaseGetDto = database.Select(x => new DatabaseGetDto() { uuid = x.uuid, name = x.name, code = x.code, server = x.server }).ToList();
            return getFinishedObject = new Answer<DatabaseGetDto>(200, "Database items founded", databaseGetDto);
        }

        [HttpDelete]
        public ActionResult<Answer<DatabaseGetDto>> DatabaseDelete(string code)
        {
            Database database = _db.Database.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);
            if (database == null)
            {
                return getFinishedObject = new Answer<DatabaseGetDto>(400, "Database not found", null);
            }
            database.isDeleted = true;
            _db.SaveChanges();
            return getFinishedObject = new Answer<DatabaseGetDto>(204, "Database deleted", null);

        }

        [HttpPut]
        public ActionResult<Answer<DatabaseGetDto>> DatabaseUpdate(DatabaseUpdateDto DatabaseUpdateDto)
        {
            Database database = _db.Database.FirstOrDefault(x => x.code.ToLower() == DatabaseUpdateDto.code.ToLower() && x.isDeleted == false);
            if (database == null)
            {
                return getFinishedObject = new Answer<DatabaseGetDto>(400, "Database not found", null);
            }
            database.name = DatabaseUpdateDto.name;
            database.server = DatabaseUpdateDto.server;
            database.port = DatabaseUpdateDto.port;
            _db.SaveChanges();
            return getFinishedObject = new Answer<DatabaseGetDto>(204, "Database updated", null);

        }

    }
}
