using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class testController : ControllerBase
    {
        private readonly DataContext _context;

        public testController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetDbEmployeeInfo(string fin)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.fin == fin);
            if (employee == null)
            {
                return StatusCode(400, "Employee not found");
            }
            List<DBEmployee> dbEmployees = _context.dBEmployees.Where(x => x.employeeId == employee.id).ToList();
            if (dbEmployees.Count <= 0)
            {
                return StatusCode(400, "dbEmployee not found for this fin");
            }

            List<string> result = new List<string>(); 
            foreach (var item in dbEmployees)
            {
                result.Add(($"id : {item.id} " + "employeId : {item.employeeId } " + $"databaseId : {item.databaseId} " + $"companyId : {item.companyId} "+ $"departmentId : {item.departmentId} " + $"projectId : {item.projectId} " + $"isActive : {item.isActive} " + $"positionId : {item.positionId} " + $"isDeleted : {item.isDelete} "));
            }

            return StatusCode(200, result);


        }
    }
}
