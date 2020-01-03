using System.Text.Json;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	public class CollectionModelSerializer
	{
		public string Serialize(CollectionModel model)
		{
			return JsonSerializer.Serialize(model);
		}
	}
}