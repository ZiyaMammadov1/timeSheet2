using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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


        [HttpPost]
        public ActionResult<Answer<ContactGetDto>> CreateContact(ContactPostDto postDto)
        {
            Database database = _context.Database.FirstOrDefault(x => x.code == postDto.dbCode);

            if (database == null)
            {
                return getFinishObject = new Answer<ContactGetDto>(400, "Database not found", null);
            }

            Employee employee = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == postDto.employeeFin.ToLower());

            if (employee == null)
            {
                return getFinishObject = new Answer<ContactGetDto>(400, "Employee not found", null);
            }
            Contact searchAnyContact = _context.Contacts.FirstOrDefault(x => x.dbId == database.id && x.employeeId == employee.id);
            if (searchAnyContact != null)
            {
                searchAnyContact.email = postDto.email;
                searchAnyContact.code = postDto.code;
                searchAnyContact.phone1 = postDto.phone1;
                searchAnyContact.phone2 = postDto.phone2;
                searchAnyContact.phone3 = postDto.phone3;
                searchAnyContact.phone4 = postDto.phone4;

                _context.SaveChanges();

                return getFinishObject = new Answer<ContactGetDto>(200, "Contact Updated", null);


            }

            Contact newContact = new Contact()
            {
                dbId = database.id,
                employeeId = employee.id,
                phone1 = postDto.phone1,
                phone2 = postDto.phone2,
                phone3 = postDto.phone3,
                phone4 = postDto.phone4,
                code = postDto.code,
                email = postDto.email
            };

            _context.Contacts.Add(newContact);
            _context.SaveChanges();

            return getFinishObject = new Answer<ContactGetDto>(200, "Contact created", null);

        }

        [HttpGet]
        public ActionResult<Answer<ContactGetDto>> GetAll()
        {
            List<Contact> contacts = _context.Contacts.Where(x => x.isDeleted == false).ToList();
            List<ContactGetDto> contactGetDto = new List<ContactGetDto>();

            if (contacts.Count > 0)
            {
                contactGetDto = contacts.Select(x => new ContactGetDto() { email = x.email, phone1 = x.phone1, phone2 = x.phone2, phone3 = x.phone3, phone4 = x.phone4 }).ToList();
                return getFinishObject = new Answer<ContactGetDto>(200, "Contact founded", contactGetDto);
            }
            return getFinishObject = new Answer<ContactGetDto>(400, "Contacts not found", null);
        }
    }
}
