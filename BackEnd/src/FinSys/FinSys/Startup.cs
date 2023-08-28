using FinSys.IoC;
using Microsoft.Extensions.DependencyInjection;
using MediatR.Extensions.Microsoft.DependencyInjection;

namespace FinSys
{
    public class Startup
    {
        public IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Injection injection = new Injection();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));

            injection.InjectionDependencies(services);
            injection.InjectServices(services);

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "FinSys", Version = "v1" });
            });
            services.AddControllers();
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinSys v1");
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           


        }
    }
}
