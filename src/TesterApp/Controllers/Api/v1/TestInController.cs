using System;
using System.Threading.Tasks;
using Simplify.Web;
using Simplify.Web.Attributes;
using TesterApp.ViewModels;

namespace TesterApp.Controllers.Api.v1
{
	[Post("/api/v1/testIn")]
	public class TestInController : AsyncController<TestViewModel>
	{
		public override async Task<ControllerResponse> Invoke()
		{
			await ReadModelAsync();

			return Content($"Prop1 = '{Model.Prop1}', Prog2 = '{Model.Prop2}'");
		}
	}
}