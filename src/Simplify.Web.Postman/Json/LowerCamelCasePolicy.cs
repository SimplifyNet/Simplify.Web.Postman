using System.Text.Json;

namespace Simplify.Web.Postman
{
	public class LowerCamelCasePolicy : JsonNamingPolicy
	{
		public override string ConvertName(string name)
		{
			if (name.Length > 0)
				return name.Substring(0, 1).ToLower() + name.Substring(1);

			return "";
		}
	}
}