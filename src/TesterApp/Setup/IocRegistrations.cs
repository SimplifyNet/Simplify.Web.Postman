using Simplify.DI;
using Simplify.Web.Bootstrapper;
using Simplify.Web.Json;
using Simplify.Web.Postman;
using Simplify.Web.Postman.Setup;

namespace TesterApp.Setup
{
	public static class IocRegistrations
	{
		public static IDIContainerProvider RegisterAll(this IDIContainerProvider containerProvider)
		{
			containerProvider.RegisterSimplifyWeb()
				.RegisterJsonModelBinder()
				.RegisterSimplifyWebPostman();

			return containerProvider;
		}
	}
}