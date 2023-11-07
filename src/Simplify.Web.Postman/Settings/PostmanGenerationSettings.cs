using System;

namespace Simplify.Web.Postman.Settings;

/// <summary>
/// Provides postman files generation settings
/// </summary>
public class PostmanGenerationSettings : IPostmanGenerationSettings
{
	private string _projectName;
	private string _collectionFileName;
	private string _collectionFileNamePostfix;
	private string _environmentFileName;
	private string _environmentFileNamePostfix;
	private string _generationFolderPath;

	/// <summary>
	/// Initializes a new instance of the <see cref="PostmanGenerationSettings" /> class.
	/// </summary>
	public PostmanGenerationSettings()
	{
		var projectAssemblyName = global::System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name ?? "App";

		_projectName = projectAssemblyName;
		_collectionFileName = projectAssemblyName;
		_collectionFileNamePostfix = ".postman_collection";
		_environmentFileName = projectAssemblyName;
		_environmentFileNamePostfix = ".postman_environment";
		_generationFolderPath = "postman";
	}

	/// <summary>
	/// Gets or sets the name of the collection.
	/// </summary>
	/// <value>
	/// The name of the collection.
	/// </value>
	public string ProjectName
	{
		get => _projectName;
		set => _projectName = value ?? throw new ArgumentNullException(nameof(value));
	}

	/// <summary>
	/// Gets or sets the name of the collection file.
	/// </summary>
	/// <value>
	/// The name of the collection file.
	/// </value>
	public string CollectionFileName
	{
		get => _collectionFileName;
		set => _collectionFileName = value ?? throw new ArgumentNullException(nameof(value));
	}

	/// <summary>
	/// Gets or sets the collection file name postfix.
	/// </summary>
	/// <value>
	/// The collection file name postfix.
	/// </value>
	public string CollectionFileNamePostfix
	{
		get => _collectionFileNamePostfix;
		set => _collectionFileNamePostfix = value ?? throw new ArgumentNullException(nameof(value));
	}

	/// <summary>
	/// Gets or sets the name of the environment file.
	/// </summary>
	/// <value>
	/// The name of the environment file.
	/// </value>
	public string EnvironmentFileName
	{
		get => _environmentFileName;
		set => _environmentFileName = value ?? throw new ArgumentNullException(nameof(value));
	}

	/// <summary>
	/// Gets or sets the environment file name postfix.
	/// </summary>
	/// <value>
	/// The environment file name postfix.
	/// </value>
	public string EnvironmentFileNamePostfix
	{
		get => _environmentFileNamePostfix;
		set => _environmentFileNamePostfix = value ?? throw new ArgumentNullException(nameof(value));
	}

	/// <summary>
	/// Gets or sets the generation folder path.
	/// </summary>
	/// <value>
	/// The generation folder path.
	/// </value>
	public string GenerationFolderPath
	{
		get => _generationFolderPath;
		set => _generationFolderPath = value ?? throw new ArgumentNullException(nameof(value));
	}
}