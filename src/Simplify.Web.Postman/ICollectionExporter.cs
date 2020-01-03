using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	/// <summary>
	/// Represents postman collection exporter
	/// </summary>
	public interface ICollectionExporter
	{
		/// <summary>
		/// Exports the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		void Export(CollectionModel model);
	}
}