using System.Collections.Generic;
using Simplify.Web.Postman.Models;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.Assembly.Environment
{
	/// <summary>
	/// Provides postman environment model builder
	/// </summary>
	public class EnvironmentBuilder
	{
		private readonly IPostmanGenerationSettings _settings;

		/// <summary>
		/// Initializes a new instance of the <see cref="EnvironmentBuilder"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public EnvironmentBuilder(IPostmanGenerationSettings settings) => _settings = settings;

		/// <summary>
		/// Creates this environment model.
		/// </summary>
		/// <returns></returns>
		public EnvironmentModel Create() =>
			new()
			{
				Name = _settings.ProjectName,
				Values = new List<PostmanValue>
					{
						new PostmanValue
						{
							Key = "BaseUrl",
							Value = "http://localhost:5000"
						}
					}
			};
	}
}