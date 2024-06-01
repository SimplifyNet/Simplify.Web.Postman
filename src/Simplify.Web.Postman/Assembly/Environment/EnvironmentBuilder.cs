using Simplify.Web.Postman.Models;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.Assembly.Environment;

/// <summary>
/// Provides postman environment model builder
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EnvironmentBuilder" /> class.
/// </remarks>
/// <param name="settings">The settings.</param>
public class EnvironmentBuilder(IPostmanGenerationSettings settings)
{
	/// <summary>
	/// Creates this environment model.
	/// </summary>
	/// <returns></returns>
	public EnvironmentModel Create() =>
		new()
		{
			Name = settings.ProjectName,
			Values =
			[
				new PostmanValue
				{
					Key = "BaseUrl",
					Value = "http://localhost:5000"
				}
			]
		};
}