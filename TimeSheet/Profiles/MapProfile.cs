using AutoMapper;
using TimeSheet.Dtos.CompanyDtos;
using TimeSheet.Dtos.DatabaseDtos;
using TimeSheet.Dtos.DepartmentDtos;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Dtos.ProjectDtos;
using TimeSheet.Dtos.RequestTypeDtos;
using TimeSheet.Dtos.StatusDtos;
using TimeSheet.Dtos.TypeOfOrderDtos;
using TimeSheet.Dtos.UserDto;
using TimeSheet.Entities;

namespace TimeSheet.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, UserGetDto>();
            //CreateMap<UserGetDto, User>();
            CreateMap<Position, PositionGetDto>();
            CreateMap<Project, ProjectGetDto>();
            CreateMap<Department, DepartmentGetDto>();
            //CreateMap<WorkType, WorkGetDto>();
            //CreateMap<mainTimeSheet, TimeSheetGetDto>();
            //CreateMap<FamilyMembers, MemberGetDto>();
            //CreateMap<MemberGetDto, FamilyMembers>();
            //CreateMap<MemberPostDto, MemberGetDto>();
            CreateMap<Company, CompanyGetDto>();
            CreateMap<DatabasePostDto, Database>();
            CreateMap<Database, DatabaseGetDto>();
            CreateMap<typeOfOrderPostDto, typeOfOrder>();
            CreateMap<typeOfOrder, typeOfOrderGetDto>();
            CreateMap<Status, StatusGetDto>();
            CreateMap<RequestType, RequestTypeGetDto>();
        }
    }
}
