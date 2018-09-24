namespace Application.Api
{
    using Api.Infrastructure.Filters;
    using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.DependencyInjection;
	using System;

	public class Configuration
	{
		public static IServiceCollection ConfigureServices(IServiceCollection services)
		{
			return services
				.AddMvcCore(config => config.Filters.Add(typeof(ValidModelStateFilter)))
				.AddJsonFormatters()
				.AddApiExplorer()
				.Services;
		}

		public static IApplicationBuilder Configure(
			IApplicationBuilder app,
			Func<IApplicationBuilder, IApplicationBuilder> configureHost) =>
			configureHost(app)
				.UseMvc(routes => routes.MapRoute("swagger", "{controller=Init}/{action=Swagger}"));
	}
}