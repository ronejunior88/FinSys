using FinSys.Command.AddExpendingCommand;
using FinSys.Command.Interfaces;

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
            services.AddSingleton<IAddExpendingCommand, AddExpendingCommand>();
        }
    }
}
