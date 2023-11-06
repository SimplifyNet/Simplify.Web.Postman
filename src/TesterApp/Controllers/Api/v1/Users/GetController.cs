using System;
using Simplify.Web;
using Simplify.Web.Attributes;
using Simplify.Web.Json.Responses;
using TesterApp.ViewModels;
using TesterApp.ViewModels.Users;

namespace TesterApp.Controllers.Api.v1.Users;

[Get("/api/v1/users/{id:int}")]
public class GetController : Simplify.Web.Controller
{
	public override ControllerResponse Invoke() =>
		 new Json(new UserViewModel
		 {
			 UserName = "User 1",
			 CreationTime = DateTime.Now
		 });
}