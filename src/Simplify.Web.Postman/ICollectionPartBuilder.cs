using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	public interface ICollectionPartBuilder
	{
		void Build(CollectionModel model);
	}
}