using Simplify.DI;

namespace Simplify.Web.Postman
{
	/// <summary>
	/// Provides Simplify.DI Simplify.Web.Postman generation extensions
	/// </summary>
	public static class SimplifyDIContextHandlerExtensions
	{
		/// <summary>
		/// Generates the postman data using Simplify.Web.Postman.
		/// </summary>
		/// <param name="contextHandler">The context handler.</param>
		/// <returns></returns>
		public static IDIContextHandler GeneratePostmanData(this IDIContextHandler contextHandler)
		{
			using var scope = contextHandler.BeginLifetimeScope();

			scope.Resolver.Resolve<PostmanGenerator>().GenerateCollection();

			return contextHandler;
		}
	}
}