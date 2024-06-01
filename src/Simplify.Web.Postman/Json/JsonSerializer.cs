using System.Text.Json;
using System.Text.Json.Serialization;

namespace Simplify.Web.Postman.Json;

/// <summary>
/// Provides postman model serializer
/// </summary>
public class JsonSerializer
{
	/// <summary>
	/// Serializes the specified model.
	/// </summary>
	/// <param name="model">The model.</param>
	public string Serialize(object model) =>
		global::System.Text.Json.JsonSerializer.Serialize(model, new JsonSerializerOptions
		{
			PropertyNamingPolicy = new LowerCamelCasePolicy(),
			WriteIndented = true,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		});
}