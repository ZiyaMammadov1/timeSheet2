//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;
//using TimeSheet.DatabaseContext;
//using TimeSheet.Dtos.RequestDtos;
//using TimeSheet.Entities;
//using TimeSheet.Helper;

//namespace TimeSheet.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class requestController : ControllerBase
//    {
//        private readonly DataContext _context;
//        Answer<RequestPostDto> getFinishObject;
//        AuthenticationManager auth;


//        public requestController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpPost] 
//        public ActionResult<Answer<RequestPostDto>> PostRequest(RequestPostDto postDto, [FromHeader] string token)
//        {
//            auth = new AuthenticationManager(_context);
//            var owner = auth.tokenOwner(auth.CurrentClaim(token));

//            List<Request> allRequest = _context.Requests.ToList();

//            Employee employee = _context.Employees.FirstOrDefault(x => x.id == owner.id);

//            if (employee == null)
//            {
//                return getFinishObject = new Answer<RequestPostDto>(400, "Employee not found.", null);
//            }

//            Database db = _context.Database.FirstOrDefault(x => x.code == postDto.dbCode);

//            if (db == null)
//            {
//                return getFinishObject = new Answer<RequestPostDto>(400, "Database not found.", null);
//            }

//            Company company = _context.Companies.FirstOrDefault(x => x.tin == postDto.tin);

//            if (company == null)
//            {
//                return getFinishObject = new Answer<RequestPostDto>(400, "Company not found.", null);
//            }

//            RequestType requestType = _context.RequestTypes.FirstOrDefault(x => x.code == postDto.type);

//            if (requestType == null)
//            {
//                return getFinishObject = new Answer<RequestPostDto>(400, "Request Type not found.", null);
//            }

//            Status status = _context.Statuses.FirstOrDefault(x => x.code == postDto.status);

//            if (status == null)
//            {
//                return getFinishObject = new Answer<RequestPostDto>(400, "Status not found.", null);
//            }

//            if (allRequest.Any(x => x.code == postDto.code))
//            {
//                return getFinishObject = new Answer<RequestPostDto>(409, "Code is conflict.", null);
//            }

//            Request newRequest = new Request()
//            {
//                employeeId = employee.id,
//                companyId = company.id,
//                databaseId = db.id,
//                requestTypeId = requestType.id,
//                statusId = status.id,
//                code = postDto.code,
//                createdDate = postDto.date,
//                dateTo = postDto.dateTo,
//                dateFrom = postDto.dateFrom,
//                description = postDto.description,
//                amount = postDto.amount
//            };

//            _context.Requests.Add(newRequest);
//            _context.SaveChanges();

//            return getFinishObject = new Answer<RequestPostDto>(200, "Request created", null);

//        }
//    }
//}
