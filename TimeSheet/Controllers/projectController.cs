using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
            if (projects.Count > 0)
            {
                List<ProjectGetDto> projectList = projects.Select(x => new ProjectGetDto() { uuid = x.uuid, name = x.name, code = x.code }).ToList();
                return getFinishObject = new Answer<ProjectGetDto>(200, "Project founded", projectList);
            }
            return getFinishObject = new Answer<ProjectGetDto>(400, "Projects not founded", null);
        }

        [HttpGet("{code}")]
        public ActionResult<Answer<ProjectGetDto>> Get(string code)
        {
            Project project = _context.Projects.FirstOrDefault(x => x.code == code && x.isDeleted == false);

            if (project != null)
            {
                return getFinishObject = new Answer<ProjectGetDto>(200, "Project founded", new List<ProjectGetDto> { _mapper.Map<ProjectGetDto>(project) });
            }
            else
            {
                return getFinishObject = new Answer<ProjectGetDto>(400, "Project not found", null);
            }
        }

        [HttpPost]
        public ActionResult<Answer<ProjectGetDto>> CreateProject(ProjectPostDto ProjectPostDto)
        {
            Database database = _context.Database.FirstOrDefault(x => x.code.ToLower() == ProjectPostDto.dbCode.ToLower());

            if (database == null)
            {
                return getFinishObject = new Answer<ProjectGetDto>(400, "Database not found", null);
            }

            if (_context.Projects.Any(x => x.code.ToLower() == ProjectPostDto.code.ToLower() && x.databaseId == database.id))
            {
                return getFinishObject = new Answer<ProjectGetDto>(409, "This project existed (code conflict!)", null);
            }

            Project project = new Project() { name = ProjectPostDto.name, code = ProjectPostDto.code, databaseId = database.id };

            _context.Projects.Add(project);
            _context.SaveChanges();

            return getFinishObject = new Answer<ProjectGetDto>(201, "Project created", null);
        }

        [HttpPut]
        public ActionResult<Answer<ProjectGetDto>> UpdateProject(ProjectUpdateDto ProjectUpdateDto)
        {
            Project project = _context.Projects.FirstOrDefault(x => x.code.ToLower() == ProjectUpdateDto.code.ToLower() && x.isDeleted == false);

            if (project == null)
            {
                return getFinishObject = new Answer<ProjectGetDto>(400, "Project not found", null);
            }

            project.name = ProjectUpdateDto.name;

            _context.SaveChanges();

            return getFinishObject = new Answer<ProjectGetDto>(204, "Project updated", null);
        }

        [HttpDelete("{code}")]
        public ActionResult<Answer<ProjectGetDto>> DeleteProject(string code)
        {
            Project project = _context.Projects.FirstOrDefault(x => x.code.ToLower() == code.ToLower() && x.isDeleted == false);

            if (project == null)
            {
                return getFinishObject = new Answer<ProjectGetDto>(400, "Project not found", null);
            }

            project.isDeleted = true;
            _context.SaveChanges();
            return getFinishObject = new Answer<ProjectGetDto>(204, "Project deleted", null);
        }

    }
}
