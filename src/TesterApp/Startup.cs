using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simplify.DI;
using Simplify.Web;
using Simplify.Web.Postman;
using TesterApp.Setup;

namespace TesterApp
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseSimplifyWebWithoutRegistrations();

			DIContainer.Current.Verify();

			if (env.IsDevelopment())
				DIContainer.Current.GeneratePostmanData();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			IocRegistrations.Register();

			DIContainer.Current.Verify();
		}
	}
}