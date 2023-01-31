using AutoMapper;
using TimeManager.DATA.Data;
using TimeManager.DATA.Data.DTO;

namespace TimeManager.DATA.Services.Automapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TaskDTO, Task_>();
    }
}