using Microsoft.AspNetCore.Mvc;
using Simplify.Web;
using Simplify.Web.Attributes;

namespace TesterApp.Controllers.Api.v1.Groups;

[Produces("application/text")]
[Authorize]
[Patch("/api/v1/groups/{id:int}/rename")]
public class RenameController : Simplify.Web.Controller
{
	public override ControllerResponse Invoke()
	{
		if (RouteParameters.id <= 0)
			return StatusCode(400, "User ID is invalid");

		return NoContent();
	}
}