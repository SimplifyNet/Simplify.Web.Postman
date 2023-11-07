using System.Collections.Generic;

#nullable disable

namespace Simplify.Web.Postman.Models;

/// <summary>
/// Provides URL model
/// </summary>
public class Url
{
	/// <summary>
	/// Gets or sets the raw.
	/// </summary>
	/// <value>
	/// The raw.
	/// </value>
	public string Host { get; set; }

	/// <summary>
	/// Gets or sets the path.
	/// </summary>
	/// <value>
	/// The path.
	/// </value>
	public IList<string> Path { get; set; }
}