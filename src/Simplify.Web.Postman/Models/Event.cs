#nullable disable

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides Event model
	/// </summary>
	public class Event
	{
		/// <summary>
		/// Get or set name of the event
		/// </summary>
		public string Listen { get; set; }

		/// <summary>
		/// Get or set the script
		/// </summary>
		public Script Script { get; set; }
	}
}