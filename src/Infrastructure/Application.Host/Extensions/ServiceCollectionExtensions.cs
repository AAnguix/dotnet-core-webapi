namespace Microsoft.Extensions.DependencyInjection
{
    using Application.Data;
    using Application.Domain;
    using Swashbuckle.AspNetCore.Swagger;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValues(this IServiceCollection services)
        {
            services.AddTransient<IValuesInteractor, ValuesInteractor>();
            services.AddTransient<IValues, InMemoryValuesRepository>();
            return services;
        }

        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            return services.AddSwaggerGen(setup =>
            {
                setup.DescribeAllParametersInCamelCase();
                setup.DescribeStringEnumsInCamelCase();
                setup.SwaggerDoc("v1", new Info
                {
                    Title = "Dotnet 2018 Api",
                    Version = "v1"
                });
            });
        }
    }
}