using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides postman collection model
	/// </summary>
	public class CollectionModel
	{
		/// <summary>
		/// Gets or sets the header.
		/// </summary>
		/// <value>
		/// The header.
		/// </value>
		public CollectionHeader? Header { get; set; }

		[JsonPropertyName("item")]
		public IList<CollectionItem> Items { get; set; } = new List<CollectionItem>();
	}
}