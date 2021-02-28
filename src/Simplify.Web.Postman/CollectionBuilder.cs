using System;
using System.Collections.Generic;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman
{
	/// <summary>
	/// Provides postman collection model builder
	/// </summary>
	public class CollectionBuilder
	{
		private readonly IList<ICollectionPartBuilder> _partBuilders;

		/// <summary>
		/// Initializes a new instance of the <see cref="CollectionBuilder"/> class.
		/// </summary>
		/// <param name="partBuilders">The part builders.</param>
		/// <exception cref="ArgumentNullException">partBuilders</exception>
		public CollectionBuilder(IList<ICollectionPartBuilder> partBuilders) => _partBuilders = partBuilders ?? throw new ArgumentNullException(nameof(partBuilders));

		/// <summary>
		/// Builds the collection model.
		/// </summary>
		/// <returns></returns>
		public CollectionModel Create()
		{
			var model = new CollectionModel();

			foreach (var partBuilder in _partBuilders)
				partBuilder.Build(model);

			return model;
		}
	}
}