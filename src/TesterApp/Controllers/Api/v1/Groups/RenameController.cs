using Microsoft.AspNetCore.Mvc;
using Simplify.Web;
using Simplify.Web.Attributes;

namespace TesterApp.Controllers.Api.v1.Groups;

[Produces("application/text")]
[Authorize]
[Patch("/api/v1/groups/{id}/rename")]
public class RenameController : Controller2
{
	public ControllerResponse Invoke(int id) =>
		id <= 0
			? StatusCode(400, "User ID is invalid")
			: NoContent();
}