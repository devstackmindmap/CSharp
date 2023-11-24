using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieRentalDbContext>(options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(MovieRentalDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IMovieRentalDbContext>(provider => provider.GetService<MovieRentalDbContext>());

            return services;
        }
    }
}
