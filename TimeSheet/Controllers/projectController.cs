using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.ProjectDtos;
using TimeSheet.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class projectController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private Answer<ProjectGetDto> getFinishObject;

        public projectController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Answer<ProjectGetDto>> GetAll()
        {

            List<Project> projects = _context.Projects.Where(x => x.isDeleted == false).ToList();
            List<ProjectGetDto> ProjectGetList = new List<ProjectGetDto>();
            foreach (var project in projects)
            {
                ProjectGetDto projectGetDto = new ProjectGetDto()
                {
                    id = project.uuid,
                    name = project.name,
                    code = project.code
                };
                ProjectGetList.Add(projectGetDto);
            }

            if (projects.Count > 0)
            {
                return getFinishObject = new Answer<ProjectGetDto>(200, "Ok", ProjectGetList);
            }
            else
            {
                return getFinishObject = new Answer<ProjectGetDto>(200, "Project not found", null);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Answer<ProjectGetDto>> Get(string id)
        {
            var exist = _context.Projects.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);
            if (exist != null)
            {
                ProjectGetDto projectGetDto = new ProjectGetDto()
                {
                    id = exist.uuid,
                    name = exist.name,
                    code = exist.code
                };
                return getFinishObject = new Answer<ProjectGetDto>(200, "Ok", new List<ProjectGetDto> { projectGetDto });
            }
            else
            {
                return getFinishObject = new Answer<ProjectGetDto>(200, "Project doesn't exist", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<ProjectGetDto>> CreateProject(ProjectPostDto ProjectPostDto)
        {
            Company company = _context.Companies.FirstOrDefault(x => x.tin == ProjectPostDto.tin);
            if (company == null)
            {
                return getFinishObject = new Answer<ProjectGetDto>(400, "Company not found", null);
            }

            Project newProject = new Project()
            {
                uuid = Guid.NewGuid().ToString(),
                isDeleted = false,
                name = ProjectPostDto.name,
                code = ProjectPostDto.code,
                companyId = company.id,
            };
            _context.Projects.Add(newProject);
            _context.SaveChanges();
            return getFinishObject = new Answer<ProjectGetDto>(201, "Project created", null);

        }

      

        [HttpPut]
        public ActionResult<Answer<ProjectGetDto>> UpdateProject(ProjectUpdateDto ProjectUpdateDto)
        {
            var exist = _context.Projects.FirstOrDefault(x => x.uuid == ProjectUpdateDto.id && x.isDeleted == false);

            if (exist == null)
            {
                return getFinishObject = new Answer<ProjectGetDto>(200, "Project doesn't exist", null);
            }

            exist.name = ProjectUpdateDto.name;
            exist.code = ProjectUpdateDto.code;

            _context.SaveChanges();

            return getFinishObject = new Answer<ProjectGetDto>(204, "No Content", null);
        }

        [HttpDelete("{id}")]
        public ActionResult<Answer<ProjectGetDto>> DeletedProject(string id)
        {
            var exist = _context.Projects.FirstOrDefault(x => x.uuid == id && x.isDeleted == false);
            if (exist == null)
            {
                return getFinishObject = new Answer<ProjectGetDto>(200, "Project not found", null);
            }
            exist.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<ProjectGetDto>(204, "No Content", null);
        }

        [HttpGet]
        [Route("properties")]
        public ActionResult<Answer<string>> GetProperty()
        {
            Answer<string> innerFinishObject;

            List<string> AllProperty = new List<string>();
            foreach (var property in typeof(Project).GetProperties())
            {
                AllProperty.Add(property.Name);
            }
            return innerFinishObject = new Answer<string>(200, "Ok", AllProperty);
        }

    }
}
