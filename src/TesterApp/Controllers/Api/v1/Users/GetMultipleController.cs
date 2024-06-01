using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Simplify.Web;
using Simplify.Web.Attributes;
using TesterApp.ViewModels.Users;

namespace TesterApp.Controllers.Api.v1.Users;

[Produces("application/json")]
[Get("/api/v1/users")]
public class GetMultipleController : Simplify.Web.Controller
{
	public override ControllerResponse Invoke()
	{
		var items = new List<UserViewModel>
		{
			new()
			{
				UserName = "User 1",
				CreationTime = DateTime.Now
			},
			new()
			{
				UserName = "User 2",
				CreationTime = DateTime.Now.Subtract(TimeSpan.FromDays(1))
			}
		};

		return Json(items);
	}
}