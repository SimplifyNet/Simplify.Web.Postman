#nullable disable

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides Postman collection model
	/// </summary>
	public class CollectionModel
	{
		/// <summary>
		/// Gets or sets the header.
		/// </summary>
		/// <value>
		/// The header.
		/// </value>
		[JsonPropertyName("info")]
		public CollectionHeader Header { get; set; }

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>
		/// The items.
		/// </value>
		[JsonPropertyName("item")]
		public IList<CollectionItem> Items { get; set; } = new List<CollectionItem>();
	}
}