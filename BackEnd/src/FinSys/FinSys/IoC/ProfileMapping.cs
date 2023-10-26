using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Service.Domain;

namespace FinSys.IoC
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<AddExpendingCommand, ExpendingDTO>().ReverseMap();
        }
    }
}
