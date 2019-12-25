using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simplify.DI;
using Simplify.Web;
using TesterApp.Setup;

namespace TesterApp
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			IocRegistrations.Register();

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseSimplifyWeb();

			DIContainer.Current.Verify();
		}

		public void ConfigureServices(IServiceCollection services)
		{
		}
	}
}