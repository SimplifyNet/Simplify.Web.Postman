#nullable disable

namespace Simplify.Web.Postman.Models;

/// <summary>
/// Provides postman value
/// </summary>
public class PostmanValue
{
	/// <summary>
	/// Gets or sets the key.
	/// </summary>
	/// <value>
	/// The key.
	/// </value>
	public string Key { get; set; }

	/// <summary>
	/// Gets or sets the value.
	/// </summary>
	/// <value>
	/// The value.
	/// </value>
	public string Value { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="PostmanValue"/> is enabled.
	/// </summary>
	/// <value>
	///   <c>true</c> if enabled; otherwise, <c>false</c>.
	/// </value>
	public bool Enabled { get; set; } = true;
}