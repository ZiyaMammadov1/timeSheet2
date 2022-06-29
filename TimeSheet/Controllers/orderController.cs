using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.CreateOrRemoveDtos;
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

        public orderController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult<Answer<string>> OrderPost(OrderPostDto orderPostDto)
        {
            Employee user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == orderPostDto.fin.ToLower());

            if (user == null)
            {
                return getFinishObject = new Answer<string>(400, "User not found", null);
            }

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


              CreateOrRemoveDto ctr = new CreateOrRemoveDto()
                {
                    OrderPostDto = orderPostDto,
                    Project = project,
                    Department = department,
                    Company = company,
                     Position = position,
                     Database = database,
                     Employee = user
                };
            int statusCode = 400;
            if (orderPostDto.orderType == 1 || orderPostDto.orderType == 2)
            {
              
                statusCode = CreateOrRemoveUser(ctr);
            }
            else if (orderPostDto.orderType == 2)
            {
                statusCode = CreateOrRemoveUser(ctr);
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

        private int CreateOrRemoveUser(CreateOrRemoveDto CRDto)
        {

            //create
            if (CRDto.OrderPostDto.orderType == 1)
            {
                DBEmployee dBEmployee = new DBEmployee()
                {
                    projectId = CRDto.Project.id,
                    departmentId = CRDto.Department.id,
                    employeeId = CRDto.Employee.id,
                    positionId = CRDto.Position.id,
                    databaseId = CRDto.Database.id,
                    companyId = CRDto.Company.id

                };

                _context.dBEmployees.Add(dBEmployee);
                _context.SaveChanges();
                return 201;
            }
            //remove
            else if (CRDto.OrderPostDto.orderType == 2)
            {
                DBEmployee currentUser = _context.dBEmployees.FirstOrDefault(x => x.databaseId == CRDto.Database.id && x.employeeId == CRDto.Employee.id &&
                                                                                 x.projectId == CRDto.Project.id && x.companyId == CRDto.Company.id && x.departmentId == CRDto.Department.id &&
                                                                                 x.positionId == CRDto.Position.id && x.isDelete == false);

                if(currentUser == null)
                {
                    return 400;
                }
                currentUser.isDelete = true;
                currentUser.isActive = false;
            }
            return 400;

        }




    }


}
