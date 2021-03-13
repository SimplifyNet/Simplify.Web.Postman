using System.Collections.Generic;
using Simplify.Web.Meta;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.PartBuilders
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
					model.Items.Add(BuildCollectionItem(item, route));
			}
		}

		private static CollectionItem BuildCollectionItem(IControllerMetaData metaData, KeyValuePair<HttpMethod, string> route) =>
			new()
			{
				Name = metaData.ControllerType.Name,
				Request = new Request
				{
					Url = new Url
					{
						Raw = route.Value
					},
					Method = route.Key.ToString().ToUpper()
				}
			};
	}
}