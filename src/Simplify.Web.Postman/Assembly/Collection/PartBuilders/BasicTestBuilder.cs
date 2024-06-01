using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Assembly.Collection.PartBuilders;

/// <summary>
/// Provides basic tests builder
/// </summary>
/// <seealso cref="ICollectionPartBuilder" />
public static class BasicTestsBuilder
{
	/// <summary>
	/// Builds the basic test.
	/// </summary>
	public static Event Build()
	{
		return new Event
		{
			Listen = "test",
			Script = new Script
			{
				Exec = ["tests[\"HTTP Code Test\"] = pm.expect(pm.response.code).to.be.oneOf([200, 204]);"],
				Type = "text/javascript"
			}
		};
	}
}