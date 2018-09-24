namespace Application.FunctionalTests
{
    using Api;
    using Application.Data;
    using Application.Domain;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.ConfigureServices(services);

            services.AddDbContext<ApplicationDbContext>(
                    options => options.UseInMemoryDatabase("InMemoryDb"));

            services
                .AddScoped<IValuesInteractor, ValuesInteractor>()
                .AddScoped<IValues, InMemoryValuesRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Configuration.Configure(app, host => host);
        }
    }
}