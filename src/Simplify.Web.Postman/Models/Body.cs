#nullable disable

namespace Simplify.Web.Postman.Models;

/// <summary>
/// provides Body model
/// </summary>
public class Body
{
	/// <summary>
	/// Gets or sets the mode.
	/// </summary>
	/// <value>
	/// The mode.
	/// </value>
	public string Mode { get; set; }

	/// <summary>
	/// Gets or sets the raw body data.
	/// </summary>
	/// <value>
	/// The raw.
	/// </value>
	public string Raw { get; set; }

	/// <summary>
	/// Gets or sets the options.
	/// </summary>
	/// <value>
	/// The options.
	/// </value>
	public BodyOptions Options { get; set; }
}