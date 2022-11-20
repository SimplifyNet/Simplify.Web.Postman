#nullable disable

using System.Text.Json.Serialization;

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides Postman collection model
	/// </summary>
	public class CollectionModel : CollectionItem
	{
		/// <summary>
		/// Gets or sets the header.
		/// </summary>
		/// <value>
		/// The header.
		/// </value>
		[JsonPropertyName("info")]
		public CollectionHeader Header { get; set; }
	}
}