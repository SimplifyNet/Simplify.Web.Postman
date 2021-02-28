using Simplify.DI;
using Simplify.Web.Bootstrapper;
using Simplify.Web.Postman;

namespace TesterApp.Setup
{
	public static class IocRegistrations
	{
		public static IDIContainerProvider RegisterAll(this IDIContainerProvider containerProvider)
		{
			containerProvider.RegisterSimplifyWeb()
				.RegisterSimplifyWebPostman();

			return containerProvider;
		}
	}
}