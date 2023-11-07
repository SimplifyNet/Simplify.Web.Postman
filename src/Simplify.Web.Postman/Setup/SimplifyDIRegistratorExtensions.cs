using System.Collections.Generic;
using Simplify.DI;
using Simplify.Web.Modules;
using Simplify.Web.Postman.Assembly.Collection;
using Simplify.Web.Postman.Assembly.Collection.PartBuilders;
using Simplify.Web.Postman.Assembly.Environment;
using Simplify.Web.Postman.Generators;
using Simplify.Web.Postman.IO;
using Simplify.Web.Postman.Json;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.Setup;

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
		registrator.RegisterSettings(settings)
			.RegisterAssembly()
			.RegisterGenerators()
			.RegisterIO()
			.RegisterJson();

	private static IDIRegistrator RegisterAssembly(this IDIRegistrator registrator) =>
		registrator.Register<CollectionHeaderBuilder>(LifetimeType.Singleton)
			.Register<CollectionItemsBuilder>(LifetimeType.Singleton)
			.Register(r => new CollectionBuilder(new List<ICollectionPartBuilder>
			{
				r.Resolve<CollectionHeaderBuilder>(),
				r.Resolve<CollectionItemsBuilder>()
			}), LifetimeType.Singleton)
			.Register<EnvironmentBuilder>(LifetimeType.Singleton);

	private static IDIRegistrator RegisterGenerators(this IDIRegistrator registrator) =>
		registrator.Register<FileBasedCollectionGenerator>()
			.Register<FileBasedEnvironmentGenerator>()
			.Register<FileBasedPostmanGenerator>();

	private static IDIRegistrator RegisterIO(this IDIRegistrator registrator) =>
		registrator.Register(r => new ModelToFileExporter(r.Resolve<JsonSerializer>(),
			r.Resolve<IEnvironment>(),
			r.Resolve<IPostmanGenerationSettings>().GenerationFolderPath));

	private static IDIRegistrator RegisterJson(this IDIRegistrator registrator) =>
		registrator.Register<JsonSerializer>(LifetimeType.Singleton);

	private static IDIRegistrator RegisterSettings(this IDIRegistrator registrator, IPostmanGenerationSettings? settings) =>
		registrator.Register(r => settings ??= new PostmanGenerationSettings(), LifetimeType.Singleton);
}