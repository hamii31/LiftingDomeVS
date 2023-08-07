namespace LiftingDome.Infrastructure.Extensions
{
	using LiftingDome.Models;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;
	using System.Reflection;
	using static Common.GeneralApplicationConstants;
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
		/// <summary>
		/// This method seeds admin role if it doesn't exist.
		/// Passed email should be of an existing user.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="email"></param>
		/// <returns></returns>
        public static IApplicationBuilder SeedAdministator(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);

            }).GetAwaiter()
              .GetResult();

            return app;
        }
    }
}
