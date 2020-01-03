using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	public interface ICollectionExporter
	{
		void Export(CollectionModel model);
	}
}