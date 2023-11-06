using Simplify.Web.Model.Validation.Attributes;

namespace TesterApp.ViewModels.Users
{
	public class UserAddViewModel
	{
		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }
	}
}