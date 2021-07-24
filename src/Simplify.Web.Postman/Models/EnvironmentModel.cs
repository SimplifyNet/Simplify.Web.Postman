using System.Collections.Generic;

#nullable disable

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides environment model
	/// </summary>
	public class EnvironmentModel
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the values.
		/// </summary>
		/// <value>
		/// The values.
		/// </value>
		public IDictionary<string, string> Values { get; set; }
	}
}