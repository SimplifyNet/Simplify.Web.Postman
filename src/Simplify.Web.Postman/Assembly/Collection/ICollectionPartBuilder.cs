using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Assembly.Collection
{
	/// <summary>
	/// Provides postman collection part builder
	/// </summary>
	public interface ICollectionPartBuilder
	{
		/// <summary>
		/// Builds the specified model part.
		/// </summary>
		/// <param name="model">The model.</param>
		void Build(CollectionModel model);
	}
}