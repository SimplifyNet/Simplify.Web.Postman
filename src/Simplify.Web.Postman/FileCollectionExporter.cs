using System.IO;
using Simplify.Web.Modules;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	public class FileCollectionExporter : ICollectionExporter
	{
		private const string GenerationFolderPath = "postman";
		private const string CollectionFileNamePostfix = ".postman_collection";

		private readonly CollectionModelSerializer _serializer;
		private readonly IEnvironment _environment;
		private readonly string _projectAssemblyName;

		public FileCollectionExporter(CollectionModelSerializer serializer, IEnvironment environment, string projectAssemblyName)
		{
			_serializer = serializer;
			_environment = environment;
			_projectAssemblyName = projectAssemblyName;
		}

		public void Export(CollectionModel model)
		{
			var folderPath = GenerateExportFolderPath();

			if (!Directory.Exists(folderPath))
				Directory.CreateDirectory(folderPath);

			File.WriteAllText(GenerateCollectionFilePath(folderPath), _serializer.Serialize(model));
		}

		public string GenerateExportFolderPath()
		{
			return Path.Combine(_environment.SitePhysicalPath, GenerationFolderPath);
		}

		public string GenerateCollectionFilePath(string folderPath)
		{
			return Path.Combine(folderPath, _projectAssemblyName + CollectionFileNamePostfix + ".json");
		}
	}
}