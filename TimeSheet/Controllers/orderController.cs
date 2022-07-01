﻿using Microsoft.AspNetCore.Cors;
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
            if (orderPostDto.orderType == "1" || orderPostDto.orderType == "2")
            {
                statusCode = CreateOrRemoveUser(ctr);
            }
            else if (orderPostDto.orderType == "2")
            {
                statusCode = CreateOrRemoveUser(ctr);
            }


            Order newOrder = new Order()

            {
                dbCode = orderPostDto.dbCode,
                fin = orderPostDto.fin,
                tin = orderPostDto.tin,
                orderType = orderPostDto.orderType,
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


            return orderResult = new Answer<OrderPostDto>(201, "Order created", null);

        }


        // OrderType = 1 or = 2

        private int CreateOrRemoveUser(CreateOrRemoveDto CRDto)
        {

            //create
            if (CRDto.OrderPostDto.orderType == "1")
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
            else if (CRDto.OrderPostDto.orderType == "2")
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
            }
            return 400;

        }

        [HttpGet]
        [Route("{fin}")]
        public ActionResult<Answer<OrderGetDto>> Get(string fin)
        {

            // burda yoxluyassan gelen tokenden ki bu tokenin fini ile burda gelen fin eynidise cavab qaytarassan
            Employee employee = _context.Employees.FirstOrDefault(a => a.fin == fin && a.isDeleted == false);

            if (employee == null)
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "Employee not found.", null);
            }

            List<DBEmployee> dbEmployees = _context.dBEmployees
                                                    .Include(x=>x.Database)
                                                    .Include(x=>x.Position)
                                                    .Include(x=>x.Depament)
                                                    .Include(x=>x.Project)
                                                    .Include(x=>x.Company)
                                                    .Where(a => a.employeeId == employee.id).ToList();




            if (dbEmployees.Count <= 0 && dbEmployees == null)
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "DbEmployees not found.", null);
            }


            DBEmployee dbEmployee = dbEmployees.FirstOrDefault();


            Order order = _context.Orders.FirstOrDefault(x => x.fin == employee.fin && x.dbCode == dbEmployee.Database.code && x.isDeleted == false);

            if (order == null)
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "Order not found.", null);
            }

            typeOfOrder orderType = _context.typeOfOrders.FirstOrDefault(x => x.code == order.orderType);

            List<IdentityCard> identityCards = _context.IdentityCards.Where(x => x.employeeId == employee.id && x.databaseId == dbEmployees.FirstOrDefault().databaseId).ToList();

            if(identityCards == null || identityCards.Count <= 0) 
            {
                return getFinishObject = new Answer<OrderGetDto>(400, "Identity Card not found.", null);
            }

            List<OrderGetDto> ordersGetDto = new List<OrderGetDto>();

            foreach (var item in identityCards)
            {
                OrderGetDto orderGetDto = new OrderGetDto()
                {
                    Position = dbEmployee.Position.name,
                    Company = dbEmployee.Company.name,
                    Department = dbEmployee.Depament.name,
                    Project = dbEmployee.Project.name,
                    code = item.code,
                    date = item.date,
                    dateEffective = order.dateEffective,
                    dateExpired = order.dateExpired,
                    dateTo = order.dateTo,
                    dbCode = dbEmployee.Database.code,
                    description = order.description,
                    fin = employee.fin,
                    salary1 = order.salary1,
                    salary2 = order.salary2,
                    salaryTotal = order.salaryTotal,
                    tin = order.tin,
                    orderType = orderType ?? null

                };
                ordersGetDto.Add(orderGetDto);
            }

            return getFinishObject = new Answer<OrderGetDto>(200, "Employee cards founded", ordersGetDto);

        }


        public class TestOrder
        {
            public string dbCode { get; set; }
            public string fin { get; set; }
            public string tin { get; set; }
            public string orderType { get; set; }
            public DateTime date { get; set; }
            public DateTime dateEffective { get; set; }
            public DateTime dateExpired { get; set; }
            public DateTime dateTo { get; set; }
            public decimal salary1 { get; set; }
            public decimal salary2 { get; set; }
            public decimal salaryTotal { get; set; }
            public string description { get; set; }
            public string code { get; set; }
            public string projectCode { get; set; }
            public string departmentCode { get; set; }
            public string positionCode { get; set; }
            public string companyCode { get; set; }

        }



        [HttpGet]
        public ActionResult<List<TestOrder>> GetAllRecord()
        {
            List<Order> orders = _context.Orders
                                         .Include(x=>x.Deprtment)
                                         .Include(x=>x.Position)
                                         .Include(x=>x.Company)
                                         .Include(x=>x.Project)
                                         .ToList();
            List<TestOrder> TOrder = new List<TestOrder>();
            foreach (var order in orders)
            {
                TestOrder testOrder = new TestOrder() 
                {
                    dbCode = order.dbCode,
                    fin = order.fin,
                    tin = order.tin,
                    orderType = order.orderType,
                    date = order.date,
                    dateEffective = order.dateEffective,
                    dateExpired = order.dateExpired,
                    dateTo = order.dateTo,
                    salary1 = order.salary1,
                    salary2 = order.salary2,
                    salaryTotal = order.salaryTotal,
                    description = order.description,
                    code = order.code,
                    projectCode = order.Project.code,
                    departmentCode = order.Deprtment.code,
                    positionCode = order.Position.code,
                    companyCode = order.Company.code

                };
                TOrder.Add(testOrder);

            }

            return TOrder;
        }

    }


}
