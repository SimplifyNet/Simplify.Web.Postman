using System.Collections.Generic;

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
	}
}