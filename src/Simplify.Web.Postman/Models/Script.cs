using System.Collections.Generic;

#nullable disable

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides Script model
	/// </summary>
	public class Script
	{
		/// <summary>
		/// Provides script commands list
		/// </summary>
		public IList<string> Exec { get; set; }

		/// <summary>
		/// Gets of sets the script type
		/// </summary>
		public string Type { get; set; }
	}
}