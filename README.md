# Simplify.Web.Postman

[![Nuget Version](https://img.shields.io/nuget/v/Simplify.Web.Postman)](https://www.nuget.org/packages/Simplify.Web.Postman/)
[![Nuget Download](https://img.shields.io/nuget/dt/Simplify.Web.Postman)](https://www.nuget.org/packages/Simplify.Web.Postman/)
[![AppVeyor branch](https://img.shields.io/appveyor/ci/i4004/simplify-web-postman/master)](https://ci.appveyor.com/project/i4004/simplify-web-postman)
[![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/Simplify.Web.Postman)](https://libraries.io/nuget/Simplify.Web.Postman)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/SimplifyNet/Simplify.Web.Postman)](https://www.codefactor.io/repository/github/simplifynet/Simplify.Web.Postman)
![Platform](https://img.shields.io/badge/platform-.NET%20Standard%202.0-lightgrey)
[![Dependabot Status](https://api.dependabot.com/badges/status?host=github&repo=SimplifyNet/Simplify.Web.Postman)](https://dependabot.com)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen)](http://makeapullrequest.com)

`Simplify.Web.Postman` is a package which provides Postman collection and environment generation extension for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework controllers.

## Quick Start

Add `GeneratePostmanData` after Simplify registration and container setup

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	if (env.IsDevelopment())
		app.UseDeveloperExceptionPage();

	app.UseSimplifyWebWithoutRegistrations();

	DIContainer.Current.RegisterAll().Verify();

	if (env.IsDevelopment())
		DIContainer.Current.GeneratePostmanData();
}
```

Postman files will generate in postman folder inside your app folder.