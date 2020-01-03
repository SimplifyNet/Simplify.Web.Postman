using Simplify.DI;
using Simplify.Web.Postman;

namespace TesterApp.Setup
{
	public static class IocRegistrations
	{
		public static void Register()
		{
			DIContainer.Current.RegisterSimplifyWebPostman();
		}
	}
}