using Simplify.DI;
using Simplify.Web.Bootstrapper;
using Simplify.Web.Postman;

namespace TesterApp.Setup
{
	public static class IocRegistrations
	{
		public static void Register()
		{
			DIContainer.Current.RegisterSimplifyWeb()
				.RegisterSimplifyWebPostman();
		}
	}
}