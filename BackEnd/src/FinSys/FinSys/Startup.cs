using FinSys.IoC;

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
            injection.InjectionDependencies(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "FinSys", Version = "v1" });
            });
            services.AddControllers();
            // Configura a injeção de dependência para a classe AppSettings
            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Outros serviços e configurações necessárias...
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

          
        }
    }
}
