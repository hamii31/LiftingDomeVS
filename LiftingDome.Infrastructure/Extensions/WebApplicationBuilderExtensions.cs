namespace LiftingDome.Infrastructure.Extensions
{
	using Microsoft.Extensions.DependencyInjection;
	using System.Reflection;

	public static class WebApplicationBuilderExtensions
	{
		/// <summary>
		/// Registers all services with their interfaces and implementations of a given assembly.
		/// The assembly is taken from the type of service interface or implementation provided.
		/// </summary>
		/// <param name="serviceType">Type of random service implementation </param>
		/// <exception cref="InvalidOperationException"></exception>
		public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
		{
			Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
			if (serviceAssembly == null)
			{
				throw new InvalidOperationException("Invalid service type provided!");
			}
			Type[] implementationTypes = serviceAssembly.GetTypes()
				.Where(t => t.Name.EndsWith("Service") && !t.IsInterface).ToArray();

			foreach (Type implementationType in implementationTypes)
			{
				Type? interfaceType = implementationType
					.GetInterface($"I{implementationType.Name}");

				if (interfaceType == null)
				{
					throw new InvalidOperationException($"No interface is provided for the service with name: {implementationType.Name}!");
				}
				services.AddScoped(interfaceType, implementationType);
			}
		}
	}
}
