namespace Application.Host
{
    using Application.Api;
    using Application.Configuration;
    using Application.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        private const string ConfigurationFilePath = "appsettings.json";

        public void ConfigureServices(IServiceCollection services)
        {
            AppConfiguration appConfiguration = new AppConfiguration(ConfigurationFilePath, false, true);

            Configuration.ConfigureServices(services)
                .AddValues()
                .AddOpenApi()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        appConfiguration.GetConnectionString(),
                        b => b.MigrationsAssembly("Application.Host")
                 ));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Configuration.Configure(
                app,
                host => host
                    .UseIf(env.IsDevelopment(), appBuilder => appBuilder.UseDeveloperExceptionPage())
                    .UseSwagger()
                    .UseSwaggerUI(setup =>
                    {
                        setup.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet 2018");
                    })
            );
        }
    }
}
