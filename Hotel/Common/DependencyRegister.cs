using Hotel.Data;
using Hotel.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Common
{
    public static class DependencyRegister
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IRoomService, RoomService>();
            //services.AddScoped<IUserContextService, UserContextService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
