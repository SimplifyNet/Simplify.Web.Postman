﻿using Simplify.Web;
using Simplify.Web.Attributes;

namespace TesterApp.Controllers
{
	[Get("status")]
	public class StatusController : Controller
	{
		public override ControllerResponse Invoke()
		{
			return Content("Service is running!");
		}
	}
}