using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.Domain;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Command.UploadExpendingCommand;
using FinSys.Service.Domain;

namespace FinSys.IoC
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<AddExpendingCommand, ExpendingDTO>().ReverseMap();
            CreateMap<UpdateExpendingCommand, ExpendingDTO>().ReverseMap();
            CreateMap<UploadExpendingCommand, Expending>().ReverseMap();
        }
    }
}
