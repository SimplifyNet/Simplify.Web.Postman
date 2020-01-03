using System;

namespace Simplify.Web.Postman
{
	public class PostmanGenerator
	{
		private readonly CollectionBuilder _builder;
		private readonly ICollectionExporter _exporter;

		public PostmanGenerator(CollectionBuilder builder, ICollectionExporter exporter)
		{
			_builder = builder ?? throw new ArgumentNullException(nameof(builder));
			_exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
		}

		public void GenerateCollection()
		{
			_exporter.Export(_builder.Create());
		}
	}
}