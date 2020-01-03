namespace Simplify.Web.Postman
{
	/// <summary>
	/// Provides default PostmanGenerationSettings factory
	/// </summary>
	public static class DefaultPostmanGenerationSettingsFactory
	{
		/// <summary>
		/// Creates the new or updates the existing settings.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="projectAssemblyName">Name of the project assembly.</param>
		/// <returns></returns>
		public static PostmanGenerationSettings CreateOrUpdateSettings(PostmanGenerationSettings? settings, string projectAssemblyName)
		{
			if (settings == null)
				settings = new PostmanGenerationSettings();

			if (settings.CollectionFileName == null)
				settings.CollectionFileName = projectAssemblyName;

			if (settings.EnvironmentFileName == null)
				settings.EnvironmentFileName = projectAssemblyName;

			return settings;
		}
	}
}