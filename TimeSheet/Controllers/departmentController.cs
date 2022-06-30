using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.DepartmentDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class departmentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Answer<DepartmentGetDto> getFinishObject;

        public departmentController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<DepartmentGetDto>> GetAll()
        {
            List<Department> departments = _context.Departments.Where(x => x.isDeleted == false).ToList();
            if (departments.Count > 0)
            {
                List<DepartmentGetDto> departmentList = new List<DepartmentGetDto>();
                foreach (var department in departments)
                {
                    Database databases = _context.Database.FirstOrDefault(x => x.isDeleted == false);

                    DepartmentGetDto GetDto = new DepartmentGetDto()
                    {
                        name = department.name,
                        uuid = department.uuid,
                        dbCode = databases.code,
                        code = department.code
                    };

                    departmentList.Add(GetDto);
                }
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Department founded", departmentList);
            }
            return getFinishObject = new Answer<DepartmentGetDto>(400, "Departments not founded", null);
        }

        [HttpGet("{code}")]
        public ActionResult<Answer<DepartmentGetDto>> Get(string code)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.code == code && x.isDeleted == false);

            if (department != null)
            {
                Database database = _context.Database.FirstOrDefault(x => x.id == department.databaseId && x.isDeleted == false);
                if(database == null)
                {
                    return getFinishObject = new Answer<DepartmentGetDto>(200, "Database not found",null);
                }

                DepartmentGetDto CurrentDepartment = new DepartmentGetDto()
                {
                    dbCode = database.code,
                    name = department.name,
                    uuid = department.uuid,
                    code = department.code
                };
                return getFinishObject = new Answer<DepartmentGetDto>(200, "Department founded", new List<DepartmentGetDto> { CurrentDepartment });
            }
            else
            {
                return getFinishObject = new Answer<DepartmentGetDto>(400, "Department not found", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<DepartmentGetDto>> CreateDepartment(DepartmentPostDto DepartmentPostDto)
        {
            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == DepartmentPostDto.dbCode.ToLower());

            if (database == null)
            {
                return getFinishObject = new Answer<DepartmentGetDto>(400, "Database not found", null);
            }

            if (_context.Departments.Any(x => x.code.ToLower() == DepartmentPostDto.code.ToLower() && x.databaseId == database.id))
            {
                return getFinishObject = new Answer<DepartmentGetDto>(409, "This department existed (code conflict!)", null);
            }

            Department department = new Department() { name = DepartmentPostDto.name, code = DepartmentPostDto.code, databaseId = database.id };

            _context.Departments.Add(department);
            _context.SaveChanges();

            return getFinishObject = new Answer<DepartmentGetDto>(201, "Department created", null);
        }

        [HttpPut]
        public ActionResult<Answer<DepartmentGetDto>> UpdateDepartment(DepartmentUpdateDto DepartmentUpdateDto)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.code.ToLower() == DepartmentUpdateDto.code.ToLower() && x.isDeleted == false);

            if (department == null)
            {
                return getFinishObject = new Answer<DepartmentGetDto>(400, "Department not found", null);
            }

            department.name = DepartmentUpdateDto.name;

            _context.SaveChanges();

            return getFinishObject = new Answer<DepartmentGetDto>(204, "Department updated", null);
        }

        [HttpDelete("{code}")]
        public ActionResult<Answer<DepartmentGetDto>> DeleteDepartment(string code)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);

            if (department == null)
            {
                return getFinishObject = new Answer<DepartmentGetDto>(400, "Department not found", null);
            }

            department.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<DepartmentGetDto>(204, "Department deleted", null);
        }




    }
}
