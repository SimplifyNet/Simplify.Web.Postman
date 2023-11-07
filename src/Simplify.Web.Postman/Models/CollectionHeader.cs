#nullable disable

namespace Simplify.Web.Postman.Models;

/// <summary>
/// Provides Postman collection header model
/// </summary>
public class CollectionHeader
{
	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	/// <value>
	/// The name.
	/// </value>
	public string Name { get; set; }

	/// <summary>
	/// Gets or sets the schema.
	/// </summary>
	/// <value>
	/// The schema.
	/// </value>
	public string Schema { get; set; } = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json";
}