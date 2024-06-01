using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Simplify.DI;
using Simplify.Web;
using Simplify.Web.Postman.Setup;
using TesterApp.Setup;

DIContainer.Current
	.RegisterAll()
	.Verify();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	DIContainer.Current.GeneratePostmanData();
}

app.UseSimplifyWeb();

await app.RunAsync();