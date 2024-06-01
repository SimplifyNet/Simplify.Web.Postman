using System;
using System.Collections.Generic;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Assembly.Collection;

/// <summary>
/// Provides postman collection model builder
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CollectionBuilder" /> class.
/// </remarks>
/// <param name="partBuilders">The part builders.</param>
/// <exception cref="ArgumentNullException">partBuilders</exception>
public class CollectionBuilder(IList<ICollectionPartBuilder> partBuilders)
{
	private readonly IList<ICollectionPartBuilder> _partBuilders = partBuilders ?? throw new ArgumentNullException(nameof(partBuilders));

	/// <summary>
	/// Builds the collection model.
	/// </summary>
	public CollectionModel Create()
	{
		var model = new CollectionModel();

		foreach (var partBuilder in _partBuilders)
			partBuilder.Build(model);

		return model;
	}
}