using System;
using Simplify.Web;
using Simplify.Web.Attributes;
using TesterApp.ViewModels;

namespace TesterApp.Controllers.Api.v1
{
	[Post("/api/v1/testIn")]
	public class TestInController : Controller<TestViewModel>
	{
		public override ControllerResponse Invoke()
		{
			throw new NotImplementedException();
		}
	}
}