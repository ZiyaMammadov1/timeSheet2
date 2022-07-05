using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        Answer<OrderGetDto> getFinishObject;
        Answer<OrderPostDto> orderResult;


        public orderController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult<Answer<OrderPostDto>> OrderPost(OrderPostDto orderPostDto)
        {
            #region CheckOrderPostDtoAllProperty
            typeOfOrder orderType = _context.typeOfOrders.FirstOrDefault(x=>x.id == orderPostDto.orderType);

            if(orderType == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Order type not found.", null);
            }
            Employee user = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == orderPostDto.fin.ToLower());

            if (user == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "User not found", null);
            }

            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == orderPostDto.dbCode.ToLower());

            if (database == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Database not found", null);
            }

            Company company = _context.Companies.FirstOrDefault(x => x.tin.ToLower() == orderPostDto.tin.ToLower());

            if (company == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Company not found", null);
            }

            Project project = _context.Projects.FirstOrDefault(x => x.code.ToLower() == orderPostDto.projectCode.ToLower());

            if (project == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Project not found", null);
            }

            Department department = _context.Departments.FirstOrDefault(x => x.code.ToLower() == orderPostDto.departmentCode.ToLower());

            if (department == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Department not found", null);
            }

            Position position = _context.Positions.FirstOrDefault(x => x.code.ToLower() == orderPostDto.positionCode.ToLower());

            if (position == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Position not found", null);
            }

            List<Order> orders = _context.Orders.ToList();

            if (orders.Any(x => x.code == orderPostDto.code))
            {
                return orderResult = new Answer<OrderPostDto>(400, "Order code is conflict.", null);
            }

            if (orders.Any(x => x.code == orderPostDto.code
                                && x.typeOfOrderId == orderPostDto.orderType
                                && x.fin == orderPostDto.fin
                                && x.dbCode == orderPostDto.dbCode
                                && x.Company.tin == orderPostDto.tin))
            {
                return orderResult = new Answer<OrderPostDto>(400, "Order already exist", null);
            }

            #endregion

            #region addOrder
            Order newOrder = new Order()

            {
                dbCode = orderPostDto.dbCode,
                fin = orderPostDto.fin,
                tin = orderPostDto.tin,
                typeOfOrderId = orderPostDto.orderType,
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
                projectId = project.id,
                dateFrom = orderPostDto.dateFrom,
                days = orderPostDto.days,
                totalDays = orderPostDto.totalDays,
                place = orderPostDto.place
            };

            if(newOrder.typeOfOrderId == 3)
            {
                if (newOrder.dateTo == null || newOrder.dateFrom == null || newOrder.totalDays == null || newOrder.days == null)
                {
                    return orderResult = new Answer<OrderPostDto>(200, "Enter all required dates for vacation (dateto, dateFrom, days, totalDays)", null);
                }
            }

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            #endregion


            List<DBEmployee> dBEmployees = _context.dBEmployees.Where(x => x.employeeId == user.id &&
                                        x.databaseId == database.id &&
                                        x.companyId == company.id &&
                                        x.projectId == project.id &&
                                        x.positionId == position.id &&
                                        x.isDelete == false).ToList();

            #region CreateOrRemoveDtoAndChecking
            if (orderPostDto.orderType == 1 && dBEmployees.Count > 0)
            {
                return orderResult = new Answer<OrderPostDto>(200, "Order already exist", null);
            }

            CreateOrRemoveDto ctr = new CreateOrRemoveDto()
            {
                OrderPostDto = orderPostDto,
                Project = project,
                Department = department,
                Company = company,
                Position = position,
                Database = database,
                Employee = user,
                OrderId = newOrder.id
            };

            int statusCode = 201;
            if (orderPostDto.orderType == 1 || orderPostDto.orderType == 2)
            {
                statusCode = CreateOrRemoveUser(ctr);
            }
            #endregion

            return orderResult = new Answer<OrderPostDto>(statusCode, "Process done", null);

        }

        private int CreateOrRemoveUser(CreateOrRemoveDto CRDto)
        {
            #region CreateOrRemoveDbEmployee
            //create
            if (CRDto.OrderPostDto.orderType == 1 || CRDto.OrderPostDto.orderType == 3)
            {
                DBEmployee dBEmployee = new DBEmployee()
                {
                    projectId = CRDto.Project.id,
                    departmentId = CRDto.Department.id,
                    employeeId = CRDto.Employee.id,
                    positionId = CRDto.Position.id,
                    databaseId = CRDto.Database.id,
                    companyId = CRDto.Company.id,
                    OrderId = CRDto.OrderId

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

                if (currentUser == null)
                {
                    return 400;
                }
                currentUser.isDelete = true;
                currentUser.isActive = false;
                _context.SaveChanges();

                return 201;
            }
            else if (CRDto.OrderPostDto.orderType == 3)
            {

            }

            return 400;

            #endregion


        }

        [HttpGet]
        [Route("{fin}")]
        public ActionResult<Answer<OrderGetDto>> GetOrders(string fin, Guid? uuid)
        {

            // burda yoxluyassan gelen tokenden ki bu tokenin fini ile burda gelen fin eynidise cavab qaytarassan
            Employee employee = _context.Employees.FirstOrDefault(a => a.fin == fin && a.isDeleted == false);

            if (employee == null)
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "Employee not found.", null);
            }

            List<DBEmployee> dbEmployees = _context.dBEmployees
                                                    .Include(x => x.Database)
                                                    .Include(x => x.Position)
                                                    .Include(x => x.Depament)
                                                    .Include(x => x.Project)
                                                    .Include(x => x.Company)
                                                    .Where(a => a.employeeId == employee.id).ToList();


            if (dbEmployees.Count <= 0 && dbEmployees == null)
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "DbEmployees not found.", null);
            }
            DBEmployee dbEmployee = dbEmployees.FirstOrDefault();
            int dbId;
            if (uuid != null)
            {
                dbEmployee = dbEmployees.FirstOrDefault(x => x.Company.uuid.ToLower() == uuid.ToString());
            }
            dbId = dbEmployee.databaseId;

            List<Order> orders = _context.Orders.Include(x => x.typeOfOrder).Where(x => x.fin == employee.fin && x.dbCode == dbEmployee.Database.code && x.isDeleted == false).ToList();

            List<OrderGetDto> ordersGetDto = new List<OrderGetDto>();

            List<typeOfOrder> typeOrderList = _context.typeOfOrders.ToList();

            foreach (var item in orders)
            {
              
                OrderGetDto orderGetDto = new OrderGetDto()
                {
                    Position = dbEmployee.Position.name,
                    Company = dbEmployee.Company.name,
                    Department = dbEmployee.Depament.name,
                    Project = dbEmployee.Project.name,
                    code = item.code,
                    date = item.date,
                    dateEffective = item.dateEffective,
                    dateExpired = item.dateExpired,
                    dateTo = item.dateTo,
                    dbCode = dbEmployee.Database.code,
                    description = item.description,
                    fin = employee.fin,
                    salary1 = item.salary1,
                    salary2 = item.salary2,
                    salaryTotal = item.salaryTotal,
                    tin = item.tin,
                    orderType = item.typeOfOrder
                };
                ordersGetDto.Add(orderGetDto);
            }

            return getFinishObject = new Answer<OrderGetDto>(200, "Orders founded", ordersGetDto);

        }



    }


}
