using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Simplify.Web;
using Simplify.Web.Attributes;
using TesterApp.ViewModels.Groups;

namespace TesterApp.Controllers.Api.v1.Groups;

[Produces("application/json")]
[Get("/api/v1/groups")]
public class GetMultipleController : Controller2
{
	public ControllerResponse Invoke()
	{
		var items = new List<GroupViewModel>
		{
			new()
			{
				Name = "Group 1"
			},
			new()
			{
				Name = "Group 2"
			}
		};

		// Items retrieve

		return Json(items);
	}
}