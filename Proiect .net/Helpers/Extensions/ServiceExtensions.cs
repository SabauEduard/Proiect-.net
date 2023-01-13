using Proiect_.net.Helpers.Jwt;
using Proiect_.net.Repositories.AuthorRepository;
using Proiect_.net.Repositories.BookRepository;
using Proiect_.net.Repositories.CategoryRepository;
using Proiect_.net.Services;

namespace Proiect_.net.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();

            return services;
        }    

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
