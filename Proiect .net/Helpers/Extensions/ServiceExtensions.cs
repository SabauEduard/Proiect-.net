using Proiect_.net.Helpers.Jwt;
using Proiect_.net.Repositories;
using Proiect_.net.Repositories.AuthorRepository;
using Proiect_.net.Repositories.BookRepository;
using Proiect_.net.Repositories.CategoryRepository;
using Proiect_.net.Repositories.UnitOfWork;
using Proiect_.net.Repositories.UserRepository;
using Proiect_.net.Services.AuthorService;
using Proiect_.net.Services.BookService;

namespace Proiect_.net.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();

            return services;
        }    
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
