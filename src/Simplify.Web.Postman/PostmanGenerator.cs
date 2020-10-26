using System;

namespace Simplify.Web.Postman
{
	/// <summary>
	///  Provides postman data generation root
	/// </summary>
	public class PostmanGenerator
	{
		private readonly CollectionBuilder _builder;
		private readonly ICollectionExporter _exporter;

		/// <summary>
		/// Initializes a new instance of the <see cref="PostmanGenerator"/> class.
		/// </summary>
		/// <param name="builder">The builder.</param>
		/// <param name="exporter">The exporter.</param>
		/// <exception cref="ArgumentNullException">
		/// builder
		/// or
		/// exporter
		/// </exception>
		public PostmanGenerator(CollectionBuilder builder, ICollectionExporter exporter)
		{
			_builder = builder ?? throw new ArgumentNullException(nameof(builder));
			_exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
		}

		/// <summary>
		/// Generates the postman collection.
		/// </summary>
		public void GenerateCollection()
		{
			_exporter.Export(_builder.Create());
		}
	}
}