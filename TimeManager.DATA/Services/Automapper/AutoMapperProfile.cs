using AutoMapper;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.DTO;

namespace TimeManager.DATA.Services.Automapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TaskDTO, Task_>()
            .ForMember(tsk => tsk.UserId, opt => opt.Ignore())
            .ForMember(tsk => tsk.Id, opt => opt.Ignore())
            .ForSourceMember(dto => dto.UserId, opt => opt.DoNotValidate());
    }
}