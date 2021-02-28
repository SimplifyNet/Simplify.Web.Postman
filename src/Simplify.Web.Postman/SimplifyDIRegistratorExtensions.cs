using System.Collections.Generic;
using Simplify.DI;
using Simplify.Web.Modules;
using Simplify.Web.Postman.Json;
using Simplify.Web.Postman.PartBuilders;
using Simplify.Web.Postman.Settings;

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
		public static IDIRegistrator RegisterSimplifyWebPostman(this IDIRegistrator registrator, IPostmanGenerationSettings? settings = null) =>
			registrator.Register(r => settings ??= new PostmanGenerationSettings(), LifetimeType.Singleton)
				.RegisterPartBuilders()
				.RegisterCollectionBuilder()
				.RegisterCollectionExporter()
				.Register<CollectionModelSerializer>()
				.Register<PostmanGenerator>();

		private static IDIRegistrator RegisterPartBuilders(this IDIRegistrator registrator) =>
			registrator.Register<CollectionHeaderBuilder>(LifetimeType.Singleton)
				.Register<CollectionItemsBuilder>(LifetimeType.Singleton);

		private static IDIRegistrator RegisterCollectionBuilder(this IDIRegistrator registrator) =>
			registrator.Register(r => new CollectionBuilder(new List<ICollectionPartBuilder>
			{
				r.Resolve<CollectionHeaderBuilder>(),
				r.Resolve<CollectionItemsBuilder>()
			}));

		private static IDIRegistrator RegisterCollectionExporter(this IDIRegistrator registrator) =>
			registrator.Register<ICollectionExporter>(r =>
					new FileCollectionExporter(r.Resolve<CollectionModelSerializer>(),
						r.Resolve<IEnvironment>(),
						r.Resolve<IPostmanGenerationSettings>()),
				LifetimeType.Singleton);
	}
}