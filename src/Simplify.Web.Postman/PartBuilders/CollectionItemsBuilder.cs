using System.Linq;
using Simplify.Web.Meta;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.PartBuilders
{
	public class CollectionItemsBuilder : ICollectionPartBuilder
	{
		public void Build(CollectionModel model)
		{
			foreach (var item in ControllersMetaStore.Current.ControllersMetaData)
			{
				model.Items.Add(BuildCollectionItem(item));
			}
		}

		private static CollectionItem BuildCollectionItem(IControllerMetaData metaData)
		{
			var route = metaData.ExecParameters.Routes.FirstOrDefault();

			var item = new CollectionItem
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

			return item;
		}
	}
}