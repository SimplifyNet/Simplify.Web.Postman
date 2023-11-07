using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simplify.DI;
using Simplify.Web;
using Simplify.Web.Json.Model.Binding;
using Simplify.Web.Model;
using Simplify.Web.Postman.Setup;
using TesterApp.Setup;

namespace TesterApp;

public class Startup
{
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
			app.UseDeveloperExceptionPage();

		HttpModelHandler.RegisterModelBinder<JsonModelBinder>();

		app.UseSimplifyWebWithoutRegistrations();

		if (env.IsDevelopment())
			DIContainer.Current.GeneratePostmanData();
	}

	public void ConfigureServices(IServiceCollection services) => InitializeContainer();

	private static void InitializeContainer() =>
		DIContainer.Current
			.RegisterAll()
			.Verify();
}