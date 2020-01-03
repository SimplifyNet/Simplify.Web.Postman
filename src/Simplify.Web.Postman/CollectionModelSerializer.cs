using System.Text.Json;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
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
			return JsonSerializer.Serialize(model);
		}
	}
}