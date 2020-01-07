﻿namespace Simplify.Web.Postman
{
	/// <summary>
	/// Provides postman files generation settings
	/// </summary>
	public class PostmanGenerationSettings
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PostmanGenerationSettings"/> class.
		/// </summary>
		public PostmanGenerationSettings()
		{
			GenerationFolderPath = "postman";
			CollectionFileNamePostfix = ".postman_collection";
			EnvironmentFileNamePostfix = ".postman_environment";
		}

		/// <summary>
		/// Gets or sets the name of the collection file.
		/// </summary>
		/// <value>
		/// The name of the collection file.
		/// </value>
		public string? CollectionFileName { get; set; }

		/// <summary>
		/// Gets or sets the collection file name postfix.
		/// </summary>
		/// <value>
		/// The collection file name postfix.
		/// </value>
		public string CollectionFileNamePostfix { get; set; }

		/// <summary>
		/// Gets or sets the name of the environment file.
		/// </summary>
		/// <value>
		/// The name of the environment file.
		/// </value>
		public string? EnvironmentFileName { get; set; }

		/// <summary>
		/// Gets or sets the environment file name postfix.
		/// </summary>
		/// <value>
		/// The environment file name postfix.
		/// </value>
		public string EnvironmentFileNamePostfix { get; set; }

		/// <summary>
		/// Gets or sets the generation folder path.
		/// </summary>
		/// <value>
		/// The generation folder path.
		/// </value>
		public string GenerationFolderPath { get; set; }
	}
}