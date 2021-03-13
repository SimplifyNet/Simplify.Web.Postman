#nullable disable

namespace Simplify.Web.Postman.Models
{
	/// <summary>
	/// Provides request model
	/// </summary>
	public class Request
	{
		/// <summary>
		/// Gets or sets the method.
		/// </summary>
		/// <value>
		/// The method.
		/// </value>
		public string Method { get; set; }

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		public Url Url { get; set; }
	}
}