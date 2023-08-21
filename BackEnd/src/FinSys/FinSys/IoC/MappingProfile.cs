using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Service.Domain;

namespace FinSys.IoC
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IMapper _mapper)
        {
            CreateMap<AddExpendingCommandRequest, ExpendingDTO>().ReverseMap();
        }
    }
}
