using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simplify.Web;
using Simplify.Web.Attributes;
using TesterApp.ViewModels.Users;

namespace TesterApp.Controllers.Api.v1.Users;

[Produces("application/text")]
[Post("/api/v1/users/create-multiple")]
public class CreateMultipleController : AsyncController<IList<UserAddViewModel>>
{
	public override async Task<ControllerResponse> Invoke()
	{
		await ReadModelAsync();

		return Content($"User created at {DateTime.Now.ToLongTimeString()}'");
	}
}