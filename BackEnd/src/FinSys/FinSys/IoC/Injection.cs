using FinSys.Command.AddExpendingCommand;
using FinSys.Command.AddSystemUserCommand;
using FinSys.Command.Domain;
using FinSys.Command.Interfaces;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Command.UpdateSystemUserCommand;
using FinSys.Command.UploadExpendingCommand;
using FinSys.Query.Interfaces;
using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using FinSys.Query.Queries.GetSystemUserAll;
using FinSys.Query.Queries.GetSystemUserById;
using FinSys.Query.Service.GetExpendingService;
using FinSys.Query.Service.GetSystemUserService;
using FinSys.Service.Expendings.AddExpendingService;
using FinSys.Service.Expendings.UpdateExpendingService;
using FinSys.Service.Expendings.UploadExpendingService;
using FinSys.Service.Interfaces;
using FinSys.Service.SystemUser.AddSystemUserService;
using FinSys.Service.SystemUser.UpdateSystemUserService;
using FluentValidation;
using MediatR;

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

            services.AddTransient<IRequestHandler<AddSystemUserCommand, UserToken>, AddSystemUserCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateSystemUserCommand, UserToken>, UpdateSystemUserCommandHandler>();
        }

        public void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IAddExpendingService, AddExpendingService>();
            services.AddScoped<IGetExpendingService, GetExpendingService>();
            services.AddScoped<IUpdateExpendingService, UpdateExpendingService>();
            services.AddScoped<IUploadExpendingService, UploadExpendingService>();

            services.AddScoped<IAddSystemUserService, AddSystemUserService>();
            services.AddScoped<IGetSystemUserService, GetSystemUserService>();
            services.AddScoped<IUpdateSystemUseService, UpdateSystemUseService>();

            services.AddScoped<IAuthenticate, Authenticate>();
        }

        public void InjectHandler(IServiceCollection services)
        {
            services.AddTransient<AddExpendingCommandHandler>();
            services.AddTransient<UpdateExpendingCommandHandler>();
            services.AddTransient<UploadExpendingCommandHandler>();
            services.AddTransient<GetExpendingsAllHandler>();
            services.AddTransient<GetExpendingsByIdHandler>();
            services.AddTransient<GetExpendingByValueHandler>();

            services.AddTransient<AddSystemUserCommandHandler>();
            services.AddTransient<UpdateSystemUserCommandHandler>();
            services.AddTransient<GetSystemUserAllHandler>();
            services.AddTransient<GetSystemUserByIdHandler>();
        }

        public void InjectValidator(IServiceCollection services)
        {
            services.AddTransient<IValidator<AddExpendingCommand>, AddExpendingCommandValidation>();
            services.AddTransient<IValidator<UpdateExpendingCommand>, UpdateExpendingCommandValidation>();

            services.AddTransient<IValidator<AddSystemUserCommand>, AddSystemUserCommandValidation>();
            services.AddTransient<IValidator<UpdateSystemUserCommand>, UpdateSystemUserCommandValidation>();
        }

        public void InjectProfiles()
        {
            var profiles = new ProfileMapping();
        }
    }
}
