using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.DatabaseDtos;
using TimeSheet.Dtos.TypeOfOrderDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class typeOfOrderController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mp;
        Answer<typeOfOrderGetDto> getFinishedObject;
        public typeOfOrderController(DataContext db, IMapper mp)
        {
            _db = db;
            _mp = mp;
        }

        [HttpPost]
        public ActionResult<Answer<typeOfOrderGetDto>> CreateOrderType(typeOfOrderPostDto typeOfOrderPostDto)
        {
            if (_db.typeOfOrders.Any(x => x.name.ToLower() == typeOfOrderPostDto.name.ToLower()))
            {
                return getFinishedObject = new Answer<typeOfOrderGetDto>(409, "This order type existed", null);
            }
            typeOfOrder type = _mp.Map<typeOfOrder>(typeOfOrderPostDto);
            _db.typeOfOrders.Add(type);
            _db.SaveChanges();
            return getFinishedObject = new Answer<typeOfOrderGetDto>(201, "Order type created", null);
        }

        [HttpGet("{code}")]
        public ActionResult<Answer<typeOfOrderGetDto>> GetOrderType(string code)
        {
            typeOfOrder type = _db.typeOfOrders.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);
            if (type == null)
            {
                return getFinishedObject = new Answer<typeOfOrderGetDto>(400, "Type not found", null);
            }
            return getFinishedObject = new Answer<typeOfOrderGetDto>(200, "Type founded", new List<typeOfOrderGetDto> { _mp.Map<typeOfOrderGetDto>(type) });

        }

        [HttpGet]
        public ActionResult<Answer<typeOfOrderGetDto>> GetAllDatabase()
        {
            List<typeOfOrder> types = _db.typeOfOrders.Where(x => x.isDeleted == false).ToList();
            if (types.Count <= 0)
            {
                return getFinishedObject = new Answer<typeOfOrderGetDto>(400, "Type items not found", null);
            }
            List<typeOfOrderGetDto> typeGetDto = types.Select(x => new typeOfOrderGetDto() { uuid = x.uuid, name = x.name, description = x.description }).ToList();
            return getFinishedObject = new Answer<typeOfOrderGetDto>(200, "Type items founded", typeGetDto);
        }

        [HttpDelete]
        public ActionResult<Answer<typeOfOrderGetDto>> TypeDelete(string code)
        {
            typeOfOrder type = _db.typeOfOrders.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);
            if (type == null)
            {
                return getFinishedObject = new Answer<typeOfOrderGetDto>(400, "Type not found", null);
            }
            type.isDeleted = true;
            _db.SaveChanges();
            return getFinishedObject = new Answer<typeOfOrderGetDto>(204, "Type deleted", null);

        }

        [HttpPut]
        public ActionResult<Answer<typeOfOrderGetDto>> DatabaseUpdate(typeOfOrderUpdateDto typeOfOrderUpdateDto)
        {
            typeOfOrder type = _db.typeOfOrders.FirstOrDefault(x => x.code.ToLower() == typeOfOrderUpdateDto.code.ToLower() && x.isDeleted == false);
            if (type == null)
            {
                return getFinishedObject = new Answer<typeOfOrderGetDto>(400, "Type not found", null);
            }
            type.name = typeOfOrderUpdateDto.name;
            type.description = typeOfOrderUpdateDto.description;
            _db.SaveChanges();
            return getFinishedObject = new Answer<typeOfOrderGetDto>(204, "Type updated", null);

        }

    }
}
