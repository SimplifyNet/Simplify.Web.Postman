using System;
using System.Collections.Generic;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	public class CollectionBuilder
	{
		private readonly IList<ICollectionPartBuilder> _partBuilders;

		public CollectionBuilder(IList<ICollectionPartBuilder> partBuilders)
		{
			_partBuilders = partBuilders ?? throw new ArgumentNullException(nameof(partBuilders));
		}

		public CollectionModel Create()
		{
			var model = new CollectionModel();

			foreach (var partBuilder in _partBuilders)
				partBuilder.Build(model);

			return model;
		}
	}
}