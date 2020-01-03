using System.IO;
using Simplify.Web.Modules;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	/// <summary>
	/// Provides postman collection to file exporter
	/// </summary>
	/// <seealso cref="ICollectionExporter" />
	public class FileCollectionExporter : ICollectionExporter
	{
		private readonly CollectionModelSerializer _serializer;
		private readonly IEnvironment _environment;
		private readonly PostmanGenerationSettings _settings;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileCollectionExporter"/> class.
		/// </summary>
		/// <param name="serializer">The serializer.</param>
		/// <param name="environment">The environment.</param>
		/// <param name="settings">The settings.</param>
		public FileCollectionExporter(CollectionModelSerializer serializer, IEnvironment environment, PostmanGenerationSettings settings)
		{
			_serializer = serializer;
			_environment = environment;
			_settings = settings;
		}

		/// <summary>
		/// Exports the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		public void Export(CollectionModel model)
		{
			var folderPath = GenerateExportFolderPath();

			if (!Directory.Exists(folderPath))
				Directory.CreateDirectory(folderPath);

			File.WriteAllText(GenerateCollectionFilePath(folderPath), _serializer.Serialize(model));
		}

		private string GenerateExportFolderPath()
		{
			return Path.Combine(_environment.SitePhysicalPath, _settings.GenerationFolderPath);
		}

		private string GenerateCollectionFilePath(string folderPath)
		{
			return Path.Combine(folderPath, _settings.CollectionFileName + _settings.CollectionFileNamePostfix + ".json");
		}
	}
}