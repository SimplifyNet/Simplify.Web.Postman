using System.Collections.Generic;
using System.Reflection;
using Simplify.DI;
using Simplify.Web.Modules;

namespace Simplify.Web.Postman
{
	/// <summary>
	/// Provides Simplify.DI Simplify.Web.Postman default registrations
	/// </summary>
	public static class SimplifyDIRegistratorExtensions
	{
		/// <summary>
		/// Registers the Simplify.Web.Postman types.
		/// </summary>
		/// <param name="registrator">The registrator.</param>
		/// <param name="settings">The settings.</param>
		/// <returns></returns>
		public static IDIRegistrator RegisterSimplifyWebPostman(this IDIRegistrator registrator, PostmanGenerationSettings? settings = null)
		{
			settings = DefaultPostmanGenerationSettingsFactory.CreateOrUpdateSettings(settings, Assembly.GetCallingAssembly().GetName().Name);

			registrator.Register(r => new CollectionBuilder(new List<ICollectionPartBuilder> { }))
				.Register<ICollectionExporter>(r => new FileCollectionExporter(r.Resolve<CollectionModelSerializer>(), r.Resolve<IEnvironment>(),
					settings))
				.Register<CollectionModelSerializer>()
				.Register<PostmanGenerator>();

			return registrator;
		}
	}
}