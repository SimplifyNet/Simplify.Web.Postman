using Simplify.Web;
using Simplify.Web.Attributes;

namespace TesterApp.Controllers.Api.v1.Users;

[Authorize]
[Delete("/api/v1/users/{id:int}")]
public class DeleteController : Simplify.Web.Controller
{
	public override ControllerResponse Invoke()
	{
		if (RouteParameters.id <= 0)
			return StatusCode(400, "User ID is invalid");

		if (RouteParameters.id > 100)
			return StatusCode(500, "Internal Server Error");

		return NoContent();
	}
}