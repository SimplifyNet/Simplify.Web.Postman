using System;
using Simplify.Web;
using Simplify.Web.Attributes;
using TesterApp.ViewModels.Users;

namespace TesterApp.Controllers.Api.v1.Users;

[Get("/api/v1/users/{id:int}")]
public class GetController : Controller
{
	public override ControllerResponse Invoke() =>
		 Json(new UserViewModel
		 {
			 UserName = "User 1",
			 CreationTime = DateTime.Now
		 });
}