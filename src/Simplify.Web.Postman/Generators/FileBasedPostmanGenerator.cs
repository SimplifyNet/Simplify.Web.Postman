namespace Simplify.Web.Postman.Generators;

/// <summary>
/// Profiles file based postman generator
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="FileBasedPostmanGenerator"/> class.
/// </remarks>
/// <param name="collectionGenerator">The collection generator.</param>
/// <param name="environmentGenerator">The environment generator.</param>
public class FileBasedPostmanGenerator(FileBasedCollectionGenerator collectionGenerator, FileBasedEnvironmentGenerator environmentGenerator)
{
	/// <summary>
	/// Generates the postman data.
	/// </summary>
	public void Generate()
	{
		collectionGenerator.Generate();
		environmentGenerator.Generate();
	}
}