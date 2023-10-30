using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Service.Domain;

namespace FinSys.IoC
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<AddExpendingCommand, ExpendingDTO>().ReverseMap();
            CreateMap<UpdateExpendingCommand, ExpendingDTO>().ReverseMap();
        }
    }
}
