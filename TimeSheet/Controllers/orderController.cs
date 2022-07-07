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
            typeOfOrder orderType = _context.typeOfOrders.FirstOrDefault(x => x.code == orderPostDto.orderType.ToString());

            if (orderType == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Order type not found.", null);
            }
            Employee user = _context.Employees.FirstOrDefault(x => x.fin == orderPostDto.fin);

            if (user == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "User not found", null);
            }

            Database database = _context.Database.FirstOrDefault(x => x.code == orderPostDto.dbCode);

            if (database == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Database not found", null);
            }

            Company company = _context.Companies.FirstOrDefault(x => x.tin == orderPostDto.tin);

            if (company == null)
            {
                return orderResult = new Answer<OrderPostDto>(400, "Company not found", null);
            }

            Project project = new Project();
            Department department = new Department();
            Position position = new Position();

      

            List<Order> orders = _context.Orders.ToList();

            if (orders.Any(x => x.code == orderPostDto.code && x.dbCode == database.code))
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
            if (orderPostDto.orderType != 1 && orderPostDto.orderType != 2)
            {
                Order order = _context.Orders
                                        .Include(x => x.Deprtment)
                                        .Include(x => x.Position)
                                        .Include(x => x.Project)
                                        .FirstOrDefault(x => x.fin == user.fin && x.dbCode == database.code && x.typeOfOrder.code == "1" && x.isDeleted ==false);
                if(order == null)
                {
                    return orderResult = new Answer<OrderPostDto>(400, "Order not found", null);
                }

                department = order.Deprtment;
                project = order.Project;
                position = order.Position;
            }
            else
            {
                project = _context.Projects.FirstOrDefault(x => x.code == orderPostDto.projectCode);

                if ((orderPostDto.orderType == 2 || orderPostDto.orderType == 1) && project == null)
                {
                    return orderResult = new Answer<OrderPostDto>(400, "Project not found", null);
                }

                department = _context.Departments.FirstOrDefault(x => x.code == orderPostDto.departmentCode);

                if ((orderPostDto.orderType == 2 || orderPostDto.orderType == 1) && department == null)
                {
                    return orderResult = new Answer<OrderPostDto>(400, "Department not found", null);
                }

                position = _context.Positions.FirstOrDefault(x => x.code == orderPostDto.positionCode);

                if ((orderPostDto.orderType == 2 || orderPostDto.orderType == 1) && position == null)
                {
                    return orderResult = new Answer<OrderPostDto>(400, "Position not found", null);
                }
            }


            #endregion

            #region addOrder
            Order newOrder = new Order()

            {
                dbCode = orderPostDto.dbCode,
                fin = orderPostDto.fin,
                tin = orderPostDto.tin,
                typeOfOrderId = orderType.id,
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

            if (newOrder.typeOfOrderId == 3)
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
            else if (CRDto.OrderPostDto.orderType == 6)
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
            var datetime = DateTime.Now;
            if (employee == null)
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "Employee not found.", null);
            }


            List<DBEmployee> dbEmployees = _context.dBEmployees.Where(a => a.employeeId == employee.id).ToList();
            List<Company> companies = _context.Companies.ToList();



            if (dbEmployees == null && dbEmployees.Count <= 0 )
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "DbEmployees not found.", null);
            }
            DBEmployee dbEmployee = dbEmployees.FirstOrDefault();
            int dbId;
            Company company = companies.FirstOrDefault(x=>x.id == dbEmployee.companyId);

            if (uuid != null)
            {

                company = companies.FirstOrDefault(x => x.uuid == uuid.ToString());
                if (company == null)
                {
                    return getFinishObject = new Answer<OrderGetDto>(400, "Company not founded.", null);
                }
                dbEmployee = dbEmployees.FirstOrDefault(x => x.companyId== company.id);
                if(dbEmployee == null)
                {
                    return getFinishObject = new Answer<OrderGetDto>(400, "DbEmployee not found with uuid.", null);
                }
            }
            dbId = dbEmployee.databaseId;

            Database db = _context.Database.Find(dbId);
            Project project = _context.Projects.Find(dbEmployee.projectId);
            Department department = _context.Departments.Find(dbEmployee.departmentId);
            Position position = _context.Positions.Find(dbEmployee.positionId);

            List<Order> orders = _context.Orders.Where(x => x.fin == employee.fin && x.dbCode == db.code && x.isDeleted == false).ToList();


            List<OrderGetDto> ordersGetDto = new List<OrderGetDto>();

            List<typeOfOrder> typeOrderList = _context.typeOfOrders.ToList();

             var ordertypes = _context.typeOfOrders;
            typeOfOrder orderType = new typeOfOrder();
            foreach (var item in orders)
            {
                orderType = ordertypes.Find(item.typeOfOrderId);
                
                OrderGetDto orderGetDto = new OrderGetDto()
                {
                    Position = position.name,
                    Company = company.name,
                    Department = department.name,
                    Project = project.name,
                    code = item.code,
                    date = item.date,
                    dateEffective = item.dateEffective,
                    dateExpired = item.dateExpired,
                    dateTo = item.dateTo,
                    dbCode = db.code,
                    description = item.description,
                    fin = employee.fin,
                    salary1 = item.salary1,
                    salary2 = item.salary2,
                    salaryTotal = item.salaryTotal,
                    tin = item.tin,
                    orderType = orderType.description

                };
                ordersGetDto.Add(orderGetDto);
            }

            return getFinishObject = new Answer<OrderGetDto>(200, "Orders founded", ordersGetDto);

        }



    }


}
