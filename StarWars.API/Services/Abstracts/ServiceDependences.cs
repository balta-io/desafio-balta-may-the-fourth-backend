namespace StarWars.API.Services.Abstracts
{
    public static class ServiceDependences
	{
		public static IServiceCollection AddServiceDependences(this IServiceCollection services)
		{
			services.AddScoped<IStarWarsService, StarWarsService>();

			return services;
		}
	}
}

