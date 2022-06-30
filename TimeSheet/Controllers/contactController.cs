using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.ContactDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class contactController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<ContactGetDto> getFinishObject;

        public contactController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public ActionResult<Answer<ContactGetDto>> CreateContact(ContactPostDto postDto)
        //{
        //    Database database = _context.Database.FirstOrDefault(x=>x.code == postDto.dbCode);

        //    if(database == null)
        //    {
        //        return getFinishObject = new Answer<ContactGetDto>(400, "Database not found", null);
        //    }

        //    Employee employee = _context.Employees.FirstOrDefault(x => x.code == postDto.employeeCode);

        //    if (employee == null)
        //    {
        //        return getFinishObject = new Answer<ContactGetDto>(400, "Employee not found", null);


        //        Contact newContact = new Contact() 
        //        {
                    
        //        };
        //}
    }
}
