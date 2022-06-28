using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.OrderDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<OrderGetDto> getFinishedObject;
        public orderController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

    }



    public class OrderProcess
    {
        private readonly DataContext _context;

        public OrderProcess(DataContext context)
        {
            _context = context;
        }
        public  string CreateUser(OrderPostDto OrderPostDto)
        {
            var message = "";
            if(OrderPostDto.fin == null)
            {
                return message = "fin not found";
            }
            if(OrderPostDto.dbCode == null)
            {
                return message = "dbCode not found";
            }
            if (OrderPostDto.companyTin == null)
            {
                return message = "companyTin not found";
            }
            
            Employee employee = _context.Employees.FirstOrDefaultAsync(x=>x.fin.ToLower() == OrderPostDto.fin.ToLower()).Result;

            if(employee == null)
            {
                return message = "Employee not found";
            }


            Project project = _context.Projects.FirstOrDefaultAsync(x => x.code.ToLower() == OrderPostDto.projectCode.ToLower()).Result;

            if (project == null)
            {
                return message = "Project not found";
            }

            Department department = _context.Departments.FirstOrDefaultAsync(x => x.code.ToLower() == OrderPostDto.departmentCode.ToLower()).Result;

            if (department == null)
            {
                return message = "Department not found";
            }

            Database database = _context.Database.FirstOrDefaultAsync(x => x.code.ToLower() == OrderPostDto.dbCode.ToLower()).Result;

            if (database == null)
            {
                return message = "Database not found";
            }

            Company company = _context.Companies.FirstOrDefaultAsync(x => x.tin.ToLower() == OrderPostDto.companyTin.ToLower()).Result;

            if (company == null)
            {
                return message = "Company not found";
            }

          
            Order newOrder = new Order()
            {
                dateFrom = OrderPostDto.dateFrom,
                departmentId = department.id,
                projectId = project.id,
                salary1 = OrderPostDto.salary1,
                salary2 = OrderPostDto.salary2,
                salaryTotal = OrderPostDto.salaryTotal,
                employeeId = employee.id,
                companyId = company.id,
                databaseId = database.id,
                description = OrderPostDto.description,
                expiryDate = OrderPostDto.expiryDate,
                dateTo = OrderPostDto.dateTo,
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return "Order created";

        }
    }
}


