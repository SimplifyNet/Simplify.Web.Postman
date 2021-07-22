using Simplify.Web.Postman.Models;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.PartBuilders
{
	/// <summary>
	/// Provides CollectionHeader builder
	/// </summary>
	/// <seealso cref="ICollectionPartBuilder" />
	public class CollectionHeaderBuilder : ICollectionPartBuilder
	{
		private readonly IPostmanGenerationSettings _settings;

		/// <summary>
		/// Initializes a new instance of the <see cref="CollectionHeaderBuilder"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public CollectionHeaderBuilder(IPostmanGenerationSettings settings) => _settings = settings;

		/// <summary>
		/// Builds the specified model part.
		/// </summary>
		/// <param name="model">The model.</param>
		public void Build(CollectionModel model) =>
			model.Header = new CollectionHeader
			{
				Name = _settings.CollectionName
			};
	}
}