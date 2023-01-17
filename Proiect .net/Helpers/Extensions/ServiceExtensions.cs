using Proiect_.net.Helpers.Jwt;
using Proiect_.net.Repositories;
using Proiect_.net.Repositories.AuthorRepository;
using Proiect_.net.Repositories.BelongsRepository;
using Proiect_.net.Repositories.BookRepository;
using Proiect_.net.Repositories.BorrowsRepository;
using Proiect_.net.Repositories.CategoryRepository;
using Proiect_.net.Repositories.PenaltyReceiptRepository;
using Proiect_.net.Repositories.PenaltyRepository;
using Proiect_.net.Repositories.UnitOfWork;
using Proiect_.net.Repositories.UserRepository;
using Proiect_.net.Repositories.WritesRepository;
using Proiect_.net.Services.AuthorService;
using Proiect_.net.Services.BookService;
using Proiect_.net.Services.BorrowsService;
using Proiect_.net.Services.CategoryService;
using Proiect_.net.Services.UserService;
using Proiect_.net.Services.WritesService;

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
            services.AddTransient<IBorrowsRepository, BorrowsRepository>();
            services.AddTransient<IBelongsRepository, BelongsRepository>();
            services.AddTransient<IWritesRepository, WritesRepository>();
            services.AddTransient<IPenaltyRepository, PenaltyRepository>();
            services.AddTransient<IPenaltyReceiptRepository, PenaltyReceiptRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWritesService, WritesService>();
            services.AddTransient<IBorrowsService, BorrowsService>();

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
