using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.Interfaces;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;

namespace FinSys.IoC
{
    public class Injection
    {
        public Injection()
        {  }

        private IConfiguration _configuration;
        private IMapper _mapper;

        public Injection(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public void InjectionDependencies(IServiceCollection services)
        {
            services.AddSingleton<IAddExpendingCommand, AddExpendingCommand>();
        }

        public void InjectionAutoMapper()
        {
            _mapper.Map<AddExpendingCommandRequest>(ExpendingDTO);
        }
    }
}
