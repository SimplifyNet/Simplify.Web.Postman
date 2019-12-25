using System;
using Simplify.Web;
using Simplify.Web.Attributes;

namespace TesterApp.Controllers.Api.v1
{
	[Get("/api/v1/testOut")]
	public class TestOutController : Controller
	{
		public override ControllerResponse Invoke()
		{
			throw new NotImplementedException();
		}
	}
}