#nullable disable

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides Postman collection item model
	/// </summary>
	public class CollectionItem
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the request.
		/// </summary>
		/// <value>
		/// The request.
		/// </value>
		public Request Request { get; set; }

		/// <summary>
		/// Gets or sets the events list.
		/// </summary>
		/// <value>
		/// The request.
		/// </value>
		public IList<Event> Event { get; set; }

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>
		/// The items.
		/// </value>
		[JsonPropertyName("item")]
		public IList<CollectionItem> Items { get; set; }
	}
}