using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Simplify.DI;
using Simplify.Web;
using Simplify.Web.Postman;
using Simplify.Web.Postman.Setup;
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

			DIContainer.Current.RegisterAll().Verify();

			if (env.IsDevelopment())
				DIContainer.Current.GeneratePostmanData();
		}
	}
}