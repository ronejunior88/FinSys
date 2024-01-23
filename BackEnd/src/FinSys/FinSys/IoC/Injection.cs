using FinSys.Command.AddExpendingCommand;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Command.UploadExpendingCommand;
using FinSys.Query.Interfaces;
using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using FinSys.Query.Service.GetExpendingService;
using FinSys.Service.Expendings.AddExpendingService;
using FinSys.Service.Expendings.UpdateExpendingService;
using FinSys.Service.Expendings.UploadExpendingService;
using FinSys.Service.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinSys.IoC
{
    public class Injection
    {
        public Injection()
        { }

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
            InjectValidator(services);
        }

        public void InjectionCommand(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddExpendingCommand>, AddExpendingCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateExpendingCommand>, UpdateExpendingCommandHandler>();
            services.AddTransient<IRequestHandler<UploadExpendingCommand>, UploadExpendingCommandHandler>();
        }

        public void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IAddExpendingService, AddExpendingService>();
            services.AddScoped<IGetExpendingService, GetExpendingService>();
            services.AddScoped<IUpdateExpendingService, UpdateExpendingService>();
            services.AddScoped<IUploadExpendingService, UploadExpendingService>();
        }

        public void InjectHandler(IServiceCollection services)
        {
            services.AddTransient<AddExpendingCommandHandler>();
            services.AddTransient<UpdateExpendingCommandHandler>();
            services.AddTransient<UploadExpendingCommandHandler>();

            services.AddTransient<GetExpendingsAllHandler>();
            services.AddTransient<GetExpendingsByIdHandler>();
            services.AddTransient<GetExpendingByValueHandler>();
        }

        public void InjectValidator(IServiceCollection services)
        {
            services.AddTransient<IValidator<AddExpendingCommand>, AddExpendingCommandValidation>();
            services.AddTransient<IValidator<UpdateExpendingCommand>, UpdateExpendingCommandValidation>();
        }

        public void InjectProfiles()
        {
            var profiles = new ProfileMapping();
        }
    }
}
