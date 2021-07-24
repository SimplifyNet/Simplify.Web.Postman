using System.Collections.Generic;
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
					model.Items.Add(BuildCollectionItem(item, route));
			}
		}

		private static CollectionItem BuildCollectionItem(IControllerMetaData metaData, KeyValuePair<HttpMethod, string> route) =>
			new()
			{
				Name = BuildName(metaData),
				Request = RequestBuilder.Build(metaData, route)
			};

		private static string BuildName(IControllerMetaData metaData) => metaData.ControllerType.Name;
	}
}