using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Simplify.Web.Controllers.Meta;
using Simplify.Web.Controllers.Meta.MetaStore;
using Simplify.Web.Controllers.Meta.Routing;
using Simplify.Web.Http;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Assembly.Collection.PartBuilders;

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
		foreach (var item in ControllersMetaStore.Current.RoutedControllers)
		{
			foreach (var route in item.ExecParameters!.Routes)
				BuildCollectionItems(model, 0, BuildRequestCollectionItem(item, route));
		}
	}

	private static void BuildCollectionItems(CollectionItem currentLevelContainer, int currentLevel, CollectionItem item)
	{
		while (true)
		{
			var path = item.Request.Url.Path;

			// If recursion reached request level or reached route parameter
			if (currentLevel == path.Count || path[currentLevel].StartsWith("{"))
			{
				currentLevelContainer.Items ??= [];

				currentLevelContainer.Items.Add(item);
				return;
			}

			// If path recursion not reached request level

			var containerName = BuildContainerName(path[currentLevel]);

			var container = currentLevelContainer.Items?.FirstOrDefault(x => x.Name == containerName);

			if (container == null)
			{
				currentLevelContainer.Items ??= [];

				container = new CollectionItem { Name = containerName, Items = [] };

				currentLevelContainer.Items.Add(container);
			}

			currentLevelContainer = container;
			currentLevel += 1;
		}
	}

	private static CollectionItem BuildRequestCollectionItem(IControllerMetadata metaData, KeyValuePair<HttpMethod, IControllerRoute> route) =>
		new()
		{
			Name = BuildRequestName(metaData),
			Request = RequestBuilder.Build(metaData, route),
			Event = [BasicTestsBuilder.Build()]
		};

	private static string BuildRequestName(IControllerMetadata metaData) => metaData.ControllerType.Name.Replace("Controller", "");

	private static string BuildContainerName(string urlPart) => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(urlPart.ToLower());
}