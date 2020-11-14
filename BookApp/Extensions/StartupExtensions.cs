using BookApp.Bll.Mappers.Books;
using BookApp.Bll.Mappers.Reservations;
using BookApp.Bll.Repositories.Books;
using BookApp.Bll.Repositories.Reservations;
using BookApp.Bll.Services.Books;
using BookApp.Bll.Services.Reservations;
using BookApp.Bll.Services.Users;
using BookApp.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookApp.Extensions
{
    public static class StartupExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();            
        }

        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddScoped<IBookMapper, BookMapper>();
            services.AddScoped<IReservationMapper, ReservationMapper>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BookAppDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
