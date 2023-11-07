namespace Simplify.Web.Postman.Settings;

/// <summary>
///  Represents postman files generation settings
/// </summary>
public interface IPostmanGenerationSettings
{
	/// <summary>
	/// Gets or sets the name of the project.
	/// </summary>
	/// <value>
	/// The name of the project.
	/// </value>
	string ProjectName { get; }

	/// <summary>
	/// Gets or sets the name of the collection file.
	/// </summary>
	/// <value>
	/// The name of the collection file.
	/// </value>
	string CollectionFileName { get; }

	/// <summary>
	/// Gets or sets the collection file name postfix.
	/// </summary>
	/// <value>
	/// The collection file name postfix.
	/// </value>
	string CollectionFileNamePostfix { get; }

	/// <summary>
	/// Gets or sets the name of the environment file.
	/// </summary>
	/// <value>
	/// The name of the environment file.
	/// </value>
	string EnvironmentFileName { get; }

	/// <summary>
	/// Gets or sets the environment file name postfix.
	/// </summary>
	/// <value>
	/// The environment file name postfix.
	/// </value>
	string EnvironmentFileNamePostfix { get; }

	/// <summary>
	/// Gets or sets the generation folder path.
	/// </summary>
	/// <value>
	/// The generation folder path.
	/// </value>
	string GenerationFolderPath { get; }
}