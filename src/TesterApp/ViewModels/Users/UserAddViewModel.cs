using System.Collections.Generic;
using Simplify.Web.Model.Validation.Attributes;
using TesterApp.ViewModels.Addresses;

namespace TesterApp.ViewModels.Users;

public class UserAddViewModel
{
	[Required]
	public string UserName { get; set; }

	[Required]
	public string Password { get; set; }

	public IList<AddressViewModel> Addresses { get; set; }
}