namespace Simplify.Web.Postman.Generators
{
	/// <summary>
	/// Profiles file based postman generator
	/// </summary>
	public class FileBasedPostmanGenerator
	{
		private readonly FileBasedCollectionGenerator _collectionGenerator;
		private readonly FileBasedEnvironmentGenerator _environmentGenerator;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileBasedPostmanGenerator"/> class.
		/// </summary>
		/// <param name="collectionGenerator">The collection generator.</param>
		/// <param name="environmentGenerator">The environment generator.</param>
		public FileBasedPostmanGenerator(FileBasedCollectionGenerator collectionGenerator, FileBasedEnvironmentGenerator environmentGenerator)
		{
			_collectionGenerator = collectionGenerator;
			_environmentGenerator = environmentGenerator;
		}

		/// <summary>
		/// Generates the postman data.
		/// </summary>
		public void Generate()
		{
			_collectionGenerator.Generate();
			_environmentGenerator.Generate();
		}
	}
}