using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Simplify.Web.Meta;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Assembly.Collection.PartBuilders
{
	/// <summary>
	/// Provides request builder
	/// </summary>
	public static class RequestBuilder
	{
		/// <summary>
		/// The base URL path.
		/// </summary>
		public const string DefaultBaseUrlPath = "{{BaseUrl}}";

		private static string? _baseUrlPath;

		/// <summary>
		/// Gets or sets the base URL path.
		/// </summary>
		public static string BaseUrlPath
		{
			get => _baseUrlPath ?? DefaultBaseUrlPath;
			set => _baseUrlPath = value ?? throw new ArgumentNullException(nameof(value));
		}

		/// <summary>
		/// Builds the request
		/// </summary>
		/// <param name="metaData">The meta data.</param>
		/// <param name="route">The route.</param>
		public static Request Build(IControllerMetaData metaData, KeyValuePair<HttpMethod, string> route) =>
			new()
			{
				Url = new Url
				{
					Host = BaseUrlPath,
					Path = BuildPath(route.Value)
				},
				Method = route.Key.ToString().ToUpper(),
				Body = TryBuildBody(metaData)
			};

		private static IList<string> BuildPath(string controllerRoute) => controllerRoute.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();

		private static Body? TryBuildBody(IControllerMetaData metaData)
		{
			if (metaData.ControllerType.BaseType!.GenericTypeArguments.Length == 0)
				return null;

			var body = new Body()
			{
				Mode = "raw",
				Raw = BuildRequestJsonData(metaData.ControllerType.BaseType.GenericTypeArguments[0]),
				Options = new()
				{
					Raw = new()
					{
						Language = "json"
					}
				}
			};

			return body;
		}

		private static string BuildRequestJsonData(Type modelType) => JsonSerializer.Serialize(CreateObject(modelType), new JsonSerializerOptions
		{
			WriteIndented = true
		});

		private static object? CreateObject(Type modelType)
		{
			if (IsGenericList(modelType))
				modelType = ConstructGenericListTypeFromGenericIList(modelType);

			return Activator.CreateInstance(modelType);
		}

		private static bool IsGenericList(Type type) => type.IsGenericType && typeof(IList<>).IsAssignableFrom(type.GetGenericTypeDefinition());

		private static Type ConstructGenericListTypeFromGenericIList(Type sourceListType)
		{
			var type = typeof(List<>);

			Type[] typeArgs = { sourceListType.GetGenericArguments()[0] };

			return type.MakeGenericType(typeArgs);
		}
	}
}