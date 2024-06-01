using System.IO;
using Simplify.Web.Postman.Assembly.Collection;
using Simplify.Web.Postman.IO;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.Generators;

/// <summary>
/// Provides file based collection generator
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="FileBasedCollectionGenerator" /> class.
/// </remarks>
/// <param name="builder">The builder.</param>
/// <param name="exporter">The exporter.</param>
/// <param name="settings">The settings.</param>
public class FileBasedCollectionGenerator(CollectionBuilder builder, ModelToFileExporter exporter, IPostmanGenerationSettings settings)
{
	/// <summary>
	/// Generates the collection
	/// </summary>
	public void Generate() => exporter.Export(builder.Create(), GenerateFileName());

	private string GenerateFileName() =>
		Path.Combine(settings.CollectionFileName + settings.CollectionFileNamePostfix + ".json");
}