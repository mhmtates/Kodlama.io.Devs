using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;


namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>
            (options => options.UseSqlServer(
             configuration.GetConnectionString("KodlamaIoDotNetCampConnectionString")));
            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ISocialMediaAddressRepository, SocialMediaAddressRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            return services;
        }
    }
}
