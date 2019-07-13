using Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Okapia.Application.Applications;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;
using Okapia.Repository;
using Okapia.Repository.Repositories;

namespace Okapia.Configuration
{
    public class Bootstrapper
    {
        private readonly IConfiguration _configuration;

        public Bootstrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Wireup(IServiceCollection services)
        {
            //services.AddSingleton<IAuthHelper, AuthHelper>();
            services.AddScoped<IJobApplication, JobApplication>();
            services.AddScoped<IJobRepository, JobRepository>();

            services.AddScoped<ICityApplication, CityApplication>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<IDistrictApplication, DistrictApplication>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();

            services.AddScoped<INeighborhoodApplication, NeighborhoodApplication>();
            services.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();

            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEmployeeApplication, EmployeeApplication>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IControllerApplication, ControllerApplication>();
            services.AddScoped<IControllerRepository, ControllerRepository>();

            services.AddSingleton<IAuthHelper, AuthHelper>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IJobPictureRepository, JobPictureRepository>();


            services.AddDbContext<OkapiaContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("OkapiaContext"));
            });
        }
    }
}