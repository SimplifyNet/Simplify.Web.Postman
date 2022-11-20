using System.Collections.Generic;
using System.Linq;
using Simplify.Web.Meta;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Assembly.Collection.PartBuilders
{
	/// <summary>
	/// Provides CollectionItems builder
	/// </summary>
	/// <seealso cref="ICollectionPartBuilder" />
	public class CollectionItemsBuilder : ICollectionPartBuilder
	{
		/// <summary>
		/// Builds the specified model part.
		/// </summary>
		/// <param name="model">The model.</param>
		public void Build(CollectionModel model)
		{
			foreach (var item in ControllersMetaStore.Current.ControllersMetaData)
			{
				// Skip any route controllers
				if (item.ExecParameters == null)
					continue;

				foreach (var route in item.ExecParameters!.Routes)
					BuildCollectionItems(model, 0, BuildRequestCollectionItem(item, route));
			}
		}

		private static void BuildCollectionItems(CollectionItem currentLevelContainer, int currentLevel, CollectionItem item)
		{
			// If recursion reached request level
			if (currentLevel == item.Request.Url.Path.Count - 1)
			{
				if (currentLevelContainer.Items == null)
					currentLevelContainer.Items = new List<CollectionItem>();

				currentLevelContainer.Items.Add(item);
				return;
			}

			// If path recursion not reached request level

			var containerName = item.Request.Url.Path[currentLevel];

			var container = currentLevelContainer.Items.FirstOrDefault(x => x.Name == containerName);

			if (container == null)
				currentLevelContainer.Items.Add(container = new CollectionItem
				{
					Name = containerName,
					Items = new List<CollectionItem>()
				});

			BuildCollectionItems(container, currentLevel + 1, item);
		}

		private static CollectionItem BuildRequestCollectionItem(IControllerMetaData metaData, KeyValuePair<HttpMethod, string> route) =>
			new()
			{
				Name = BuildName(metaData),
				Request = RequestBuilder.Build(metaData, route)
			};

		private static string BuildName(IControllerMetaData metaData) => metaData.ControllerType.Name;
	}
}