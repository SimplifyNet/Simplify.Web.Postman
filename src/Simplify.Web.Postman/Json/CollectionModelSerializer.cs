using System.Text.Json;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Json
{
	/// <summary>
	/// Provides postman collection model serializer
	/// </summary>
	public class CollectionModelSerializer
	{
		/// <summary>
		/// Serializes the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		public string Serialize(CollectionModel model)
		{
			return JsonSerializer.Serialize(model, new JsonSerializerOptions
			{
				PropertyNamingPolicy = new LowerCamelCasePolicy(),
				WriteIndented = true
			});
		}
	}
}