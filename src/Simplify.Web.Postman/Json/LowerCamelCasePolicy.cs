using System.Text.Json;

namespace Simplify.Web.Postman.Json;

/// <summary>
/// Provides lower camel case policy
/// </summary>
/// <seealso cref="JsonNamingPolicy" />
public class LowerCamelCasePolicy : JsonNamingPolicy
{
	/// <summary>
	/// When overridden in a derived class, converts the specified name according to the policy.
	/// </summary>
	/// <param name="name">The name to convert.</param>
	/// <returns>
	/// The converted name.
	/// </returns>
	public override string ConvertName(string name)
	{
		if (name.Length > 0)
			return name.Substring(0, 1).ToLower() + name.Substring(1);

		return "";
	}
}