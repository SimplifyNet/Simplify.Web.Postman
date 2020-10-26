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
		public static IDIRegistrator RegisterSimplifyWebPostman(this IDIRegistrator registrator, IPostmanGenerationSettings? settings = null)
		{
			registrator.Register(r => settings ??= new PostmanGenerationSettings(), LifetimeType.Singleton);

			registrator.RegisterPartBuilders()
				.RegisterCollectionBuilder()
				.RegisterCollectionExporter();

			registrator.Register<CollectionModelSerializer>()
				.Register<PostmanGenerator>();

			return registrator;
		}

		private static IDIRegistrator RegisterPartBuilders(this IDIRegistrator registrator)
		{
			registrator.Register<CollectionHeaderBuilder>(LifetimeType.Singleton)
				.Register<CollectionItemsBuilder>(LifetimeType.Singleton);

			return registrator;
		}

		private static IDIRegistrator RegisterCollectionBuilder(this IDIRegistrator registrator)
		{
			return registrator.Register(r => new CollectionBuilder(new List<ICollectionPartBuilder>
			{
				r.Resolve<CollectionHeaderBuilder>(),
				r.Resolve<CollectionItemsBuilder>()
			}));
		}

		private static IDIRegistrator RegisterCollectionExporter(this IDIRegistrator registrator)
		{
			return registrator.Register<ICollectionExporter>(r =>
					new FileCollectionExporter(r.Resolve<CollectionModelSerializer>(),
						r.Resolve<IEnvironment>(),
						r.Resolve<IPostmanGenerationSettings>()),
				LifetimeType.Singleton);
		}
	}
}