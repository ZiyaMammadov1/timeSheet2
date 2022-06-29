using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.OrderDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class orderController : ControllerBase
    {
        private readonly DataContext _context;
        Answer<string> getFinishObject;

        public orderController(DataContext dataContext)
        {
            _context = _context;
        }


        [HttpPost]
        public ActionResult<Answer<string>> OrderPost(OrderPostDto orderPostDto)
        {



            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == orderPostDto.dbCode.ToLower());

            if (database == null)
            {
                return getFinishObject = new Answer<string>(400, "Database not found", null);
            }

            Company company = _context.Companies.FirstOrDefault(x => x.tin.ToLower() == orderPostDto.tin.ToLower());

            if (company == null)
            {
                return getFinishObject = new Answer<string>(400, "Company not found", null);
            }



            Project project = _context.Projects.FirstOrDefault(x => x.code.ToLower() == orderPostDto.projectCode.ToLower());

            if (project == null)
            {
                return getFinishObject = new Answer<string>(400, "Project not found", null);
            }

            Department department = _context.Departments.FirstOrDefault(x => x.code.ToLower() == orderPostDto.departmentCode.ToLower());

            if (department == null)
            {
                return getFinishObject = new Answer<string>(400, "Department not found", null);
            }

            Position position = _context.Positions.FirstOrDefault(x => x.code.ToLower() == orderPostDto.positionCode.ToLower());

            if (position == null)
            {
                return getFinishObject = new Answer<string>(400, "Position not found", null);
            }


            int statusCode = 400;
            if (orderPostDto.orderType == 1 || orderPostDto.orderType == 2)
            {
                statusCode = CreateOrRemoveUser(orderPostDto,project,department,company,position,database);
            }
            else if (orderPostDto.orderType == 2)
            {
                statusCode = CreateOrRemoveUser(orderPostDto, project, department, company, position,database);
            }


            Order newOrder = new Order()

            {
                dbCode = orderPostDto.dbCode,
                fin = orderPostDto.fin,
                tin = orderPostDto.tin,
                orderType = orderPostDto.code,
                date = orderPostDto.date,
                dateEffective = orderPostDto.dateEffective,
                dateExpired = orderPostDto.dateExpired,
                code = orderPostDto.code,
                dateTo = orderPostDto.dateTo,
                salary1 = orderPostDto.salary1,
                salary2 = orderPostDto.salary2,
                salaryTotal = orderPostDto.salaryTotal,
                description = orderPostDto.description,
                companyId = company.id,
                deprtmentID = department.id,
                positionId = position.id,
                projectId = project.id

            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            return getFinishObject = new Answer<string>(201, "Order created", null);




        }


        // OrderType = 1 or = 2

        public int CreateOrRemoveUser(OrderPostDto orderPostDto,Project project,
                                      Department department,Company company, Position position,Database database)
        {

            //create
            if (orderPostDto.orderType == 1)
            {
                DBEmployee dBEmployee = new DBEmployee()
                {
                    projectId = project.id,
                    departmentId = department.id,
                    employeeId = 5,
                    positionId = position.id,
                    databaseId = database.id

                };
            }
            //remove
            else if (orderPostDto.orderType == 2)
            {

            }
            return 400;

        }




    }


}
