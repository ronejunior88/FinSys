using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Service.Domain;

namespace FinSys.IoC
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {    }

        public ProfileMapping(IMapper _mapper)
        {
            CreateMap<AddExpendingCommand, ExpendingDTO>().ReverseMap();
        }
    }
}
