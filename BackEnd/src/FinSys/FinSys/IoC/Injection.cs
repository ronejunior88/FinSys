using FinSys.Command.AddExpendingCommand;
using FinSys.Service.Expendings.AddExpendingService;
using FinSys.Service.Interfaces;
using MediatR;

namespace FinSys.IoC
{
    public class Injection
    {
        public Injection()
        {  }

        private IConfiguration _configuration;

        public Injection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void InjectionDependencies(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddExpendingCommand>, AddExpendingCommandHandler>();
        }

        public void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IAddExpendingService, AddExpendingService>();
        }

        public void InjectProfiles()
        {
            var profiles = new ProfileMapping();
        }
    }
}
