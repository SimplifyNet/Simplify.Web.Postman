using System;
using System.Collections.Generic;
using System.Text.Json;
using Simplify.Web.Controllers.Meta;
using Simplify.Web.Controllers.Meta.Routing;
using Simplify.Web.Http;
using Simplify.Web.Postman.Models;

namespace Simplify.Web.Postman.Assembly.Collection.PartBuilders;

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
	public static Request Build(IControllerMetadata metaData, KeyValuePair<HttpMethod, IControllerRoute> route) =>
		new()
		{
			Url = new Url
			{
				Host = BaseUrlPath,
				Path = BuildPath(route.Value.Path)
			},
			Method = route.Key.ToString().ToUpper(),
			Body = TryBuildBody(metaData)
		};

	private static IList<string> BuildPath(string controllerRoute) => [.. controllerRoute.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)];

	private static Body? TryBuildBody(IControllerMetadata metaData)
	{
		if (metaData.ControllerType.BaseType!.GenericTypeArguments.Length == 0)
			return null;

		var body = new Body()
		{
			Mode = "raw",
			Raw = BuildRequestJsonData(metaData.ControllerType.BaseType.GenericTypeArguments[0]),
			Options = new BodyOptions
			{
				Raw = new BodyRawOptions
				{
					Language = "json"
				}
			}
		};

		return body;
	}

	private static string BuildRequestJsonData(Type modelType)
	{
		var model = CreateObject(modelType);

		InitializeListsSingleEmptyValues(model);

		return JsonSerializer.Serialize(model, new JsonSerializerOptions
		{
			WriteIndented = true
		});
	}

	private static object CreateObject(Type modelType)
	{
		if (IsGenericList(modelType))
			modelType = ConstructGenericListTypeFromGenericIList(modelType);

		return Activator.CreateInstance(modelType) ?? throw new InvalidOperationException("Error creating model.");
	}

	private static bool IsGenericList(Type type) => type.IsGenericType && typeof(IList<>).IsAssignableFrom(type.GetGenericTypeDefinition());

	private static Type ConstructGenericListTypeFromGenericIList(Type sourceListType)
	{
		var type = typeof(List<>);

		Type[] typeArgs = [sourceListType.GetGenericArguments()[0]];

		return type.MakeGenericType(typeArgs);
	}

	private static void InitializeListsSingleEmptyValues(object model)
	{
		var type = model.GetType();

		foreach (var propertyInfo in type.GetProperties())
		{
			if (!IsGenericList(propertyInfo.PropertyType))
				continue;

			var listObjectType = propertyInfo.PropertyType.GetGenericArguments()[0];
			var emptyListType = ConstructGenericListTypeFromGenericIList(propertyInfo.PropertyType);

			var emptyList = Activator.CreateInstance(emptyListType);
			var emptyItem = Activator.CreateInstance(listObjectType);

			emptyListType.GetMethod("Add")!.Invoke(emptyList, [emptyItem]);

			propertyInfo.SetValue(model, emptyList);
		}
	}
}