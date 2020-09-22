using Simplify.Web.Postman.Models;
using Simplify.Web.Postman.Settings;

namespace Simplify.Web.Postman.PartBuilders
{
	public class CollectionHeaderBuilder : ICollectionPartBuilder
	{
		private readonly IPostmanGenerationSettings _settings;

		public CollectionHeaderBuilder(IPostmanGenerationSettings settings)
		{
			_settings = settings;
		}

		public void Build(CollectionModel model)
		{
			model.Header = new CollectionHeader
			{
				Name = _settings.CollectionName
			};
		}
	}
}