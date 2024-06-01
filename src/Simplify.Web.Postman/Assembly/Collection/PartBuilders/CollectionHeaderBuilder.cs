using Simplify.Web.Postman.Models;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.Assembly.Collection.PartBuilders;

/// <summary>
/// Provides CollectionHeader builder
/// </summary>
/// <seealso cref="ICollectionPartBuilder" />
/// <remarks>
/// Initializes a new instance of the <see cref="CollectionHeaderBuilder"/> class.
/// </remarks>
/// <param name="settings">The settings.</param>
public class CollectionHeaderBuilder(IPostmanGenerationSettings settings) : ICollectionPartBuilder
{
	/// <summary>
	/// Builds the specified model part.
	/// </summary>
	/// <param name="model">The model.</param>
	public void Build(CollectionModel model) =>
		model.Header = new CollectionHeader
		{
			Name = settings.ProjectName
		};
}