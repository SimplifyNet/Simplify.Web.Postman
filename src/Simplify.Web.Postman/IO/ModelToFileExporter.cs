using System.IO;
using Simplify.Web.Modules.ApplicationEnvironment;
using Simplify.Web.Postman.Json;

namespace Simplify.Web.Postman.IO;

/// <summary>
/// Provides model to file exporter
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ModelToFileExporter" /> class.
/// </remarks>
/// <param name="serializer">The serializer.</param>
/// <param name="environment">The environment.</param>
/// <param name="generationFolderPath">The generation folder path.</param>
public class ModelToFileExporter(JsonSerializer serializer, IEnvironment environment, string generationFolderPath)
{
	/// <summary>
	/// Exports the specified model.
	/// </summary>
	/// <param name="model">The model.</param>
	/// <param name="fileName">Name of the file.</param>
	public void Export(object model, string fileName)
	{
		var folderPath = GenerateExportFolderPath();

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		File.WriteAllText(GenerateCollectionFilePath(folderPath, fileName), serializer.Serialize(model));
	}

	private static string GenerateCollectionFilePath(string folderPath, string fileName) => Path.Combine(folderPath, fileName);

	private string GenerateExportFolderPath() => Path.Combine(environment.AppPhysicalPath, generationFolderPath);
}