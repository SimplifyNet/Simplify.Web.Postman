using System.IO;
using Simplify.Web.Postman.Assembly.Environment;
using Simplify.Web.Postman.IO;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.Generators
{
	/// <summary>
	/// Provides file based postman environment generator
	/// </summary>
	public class FileBasedEnvironmentGenerator
	{
		private readonly EnvironmentBuilder _builder;
		private readonly ModelToFileExporter _exporter;
		private readonly IPostmanGenerationSettings _settings;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileBasedCollectionGenerator" /> class.
		/// </summary>
		/// <param name="builder">The builder.</param>
		/// <param name="exporter">The exporter.</param>
		/// <param name="settings">The settings.</param>
		public FileBasedEnvironmentGenerator(EnvironmentBuilder builder, ModelToFileExporter exporter, IPostmanGenerationSettings settings)
		{
			_exporter = exporter;
			_builder = builder;
			_settings = settings;
		}

		/// <summary>
		/// Generates the collection
		/// </summary>
		public void Generate() => _exporter.Export(_builder.Create(), GenerateFileName());

		private string GenerateFileName() =>
			Path.Combine(_settings.EnvironmentFileName + _settings.EnvironmentFileNamePostfix + ".json");
	}
}