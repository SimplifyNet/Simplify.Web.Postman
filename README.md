# Simplify.Web.Postman

[![Nuget Version](https://img.shields.io/nuget/v/Simplify.Web.Postman)](https://www.nuget.org/packages/Simplify.Web.Postman/)
[![Nuget Download](https://img.shields.io/nuget/dt/Simplify.Web.Postman)](https://www.nuget.org/packages/Simplify.Web.Postman/)
[![Build Package](https://github.com/SimplifyNet/Simplify.Web.Postman/actions/workflows/build.yml/badge.svg)](https://github.com/SimplifyNet/Simplify.Web.Postman/actions/workflows/build.yml)[![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/Simplify.Web.Postman)](https://libraries.io/nuget/Simplify.Web.Postman)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/SimplifyNet/Simplify.Web.Postman)](https://www.codefactor.io/repository/github/simplifynet/Simplify.Web.Postman)
![Platform](https://img.shields.io/badge/platform-.NET%206.0%20%7C%20.NET%20Standard%202.0-lightgrey)

`Simplify.Web.Postman` is a package which provides Postman collection and environment generation extension for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework controllers.

## Quick Start

1. Add `RegisterSimplifyWebPostman` to IOC container registrations.

```csharp
public static class IocRegistrations
{
 public static IDIContainerProvider RegisterAll(this IDIContainerProvider containerProvider)
 {
  containerProvider.RegisterSimplifyWeb()
   .RegisterSimplifyWebPostman();

  return containerProvider;
 }
}
```

2. Use `GeneratePostmanData` after Simplify registration and container setup

```csharp
DIContainer.Current
    .RegisterAll()
    .Verify();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

if (builder.Environment.IsDevelopment())
    DIContainer.Current.GeneratePostmanData();

app.UseSimplifyWeb();

await app.RunAsync();
```

Postman files will be generated in `postman` folder inside your app build folder.
