using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class positionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<PositionGetDto> getFinishObject;
        public positionController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<PositionGetDto>> GetAll()
        {
            List<Position> position = _context.Positions.Where(x => x.isDeleted == false).ToList();
            if (position.Count > 0)
            {
                List<PositionGetDto> positionList = position.Select(x => new PositionGetDto() { uuid = x.uuid, name = x.name }).ToList();
                return getFinishObject = new Answer<PositionGetDto>(200, "Position founded", positionList);
            }
            return getFinishObject = new Answer<PositionGetDto>(400, "Position not founded", null);
        }

        [HttpGet("{code}")]
        public ActionResult<Answer<PositionGetDto>> Get(string code)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);

            if (position != null)
            {
                return getFinishObject = new Answer<PositionGetDto>(200, "Position founded", new List<PositionGetDto> { _mapper.Map<PositionGetDto>(position) });
            }
            else
            {
                return getFinishObject = new Answer<PositionGetDto>(400, "Position not found", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<PositionGetDto>> CreatePosition(PositionPostDto PositionPostDto)
        {
            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == PositionPostDto.dbCode.ToLower() && x.isDeleted == false);

            if (database == null)
            {
                return getFinishObject = new Answer<PositionGetDto>(400, "Database not found", null);
            }

            if (_context.Positions.Any(x => x.code.ToLower() == PositionPostDto.code.ToLower() && x.databaseId == database.id))
            {
                return getFinishObject = new Answer<PositionGetDto>(409, "This position existed (code conflict!) ", null);
            }

            Position position = new Position() { name = PositionPostDto.name, code = PositionPostDto.code, databaseId = database.id };

            _context.Positions.Add(position);
            _context.SaveChanges();

            return getFinishObject = new Answer<PositionGetDto>(201, "Position created", null);
        }

        [HttpPut]
        public ActionResult<Answer<PositionGetDto>> UpdatePosition(PositionUpdateDto PositionUpdateDto)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.code.ToLower() == PositionUpdateDto.code.ToLower() && x.isDeleted == false);

            if (position == null)
            {
                return getFinishObject = new Answer<PositionGetDto>(400, "Position not found", null);
            }

            position.name = PositionUpdateDto.name;

            _context.SaveChanges();

            return getFinishObject = new Answer<PositionGetDto>(204, "Position updated", null);
        }

        [HttpDelete("{code}")]
        public ActionResult<Answer<PositionGetDto>> DeletePosition(string code)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);

            if (position == null)
            {
                return getFinishObject = new Answer<PositionGetDto>(400, "Position not found", null);
            }

            position.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<PositionGetDto>(204, "Position deleted", null);
        }


    }
}
