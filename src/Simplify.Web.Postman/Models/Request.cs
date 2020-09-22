#nullable disable

namespace Simplify.Web.Postman.Models
{
	public class Request
	{
		public string Method { get; set; }

		public Url Url { get; set; }
	}
}