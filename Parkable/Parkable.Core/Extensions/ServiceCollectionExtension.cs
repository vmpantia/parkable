using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Parkable.Core.Behaviors;
using Parkable.Core.Users;
using Parkable.Core.Users.Inferfaces;
using System.Reflection;

namespace Parkable.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSingleton<ITokenProvider, TokenProvider>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
        }

        private static void AddMediatR(this IServiceCollection services) =>
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                config.AddOpenBehavior(typeof(DbTransactionPipelineBehavior<,>));
            });
    }
}
