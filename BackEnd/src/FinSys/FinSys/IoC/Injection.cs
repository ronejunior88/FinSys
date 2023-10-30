using FinSys.Command.AddExpendingCommand;
using FinSys.Query.Interfaces;
using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using FinSys.Query.Service.GetExpendingService;
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
            InjectProfiles();
            InjectionCommand(services);
            InjectServices(services);
            InjectHandler(services);
        }

        public void InjectionCommand(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddExpendingCommand>, AddExpendingCommandHandler>();
        }

        public void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IAddExpendingService, AddExpendingService>();
            services.AddScoped<IGetExpendingService, GetExpendingService>();
        }

        public void InjectHandler(IServiceCollection services)
        {
            services.AddTransient<GetExpendingsAllHandler>();
            services.AddTransient<GetExpendingsByIdHandler>();
            services.AddTransient<GetExpendingByValueHandler>();
        }

        public void InjectProfiles()
        {
            var profiles = new ProfileMapping();
        }
    }
}
