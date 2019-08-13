using Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Okapia.Application.Applications;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;
using Okapia.Domain.QueryContracts;
using Okapia.Query;
using Okapia.Query.Query;
using Okapia.Repository;
using Okapia.Repository.Repositories;
using Okapia.WebService.Adapter;
using Okapia.WebService.Adapter.Contracts;

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

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEmployeeApplication, EmployeeApplication>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IControllerApplication, ControllerApplication>();
            services.AddScoped<IControllerRepository, ControllerRepository>();

            services.AddScoped<IGroupApplication, GroupApplication>();
            services.AddScoped<IGroupRepository, GroupRepository>();

            services.AddScoped<IModalApplication, ModalApplication>();
            services.AddScoped<IModalRepository, ModalRepository>();

            services.AddScoped<IJobRequestApplication, JobRequestApplication>();
            services.AddScoped<IJobRequestRepository, JobRequestRepository>();

            services.AddScoped<IMarketerApplication, MarketerApplication>();
            services.AddScoped<IMarketerRepository, MarketerRepository>();

            services.AddScoped<IPageApplication, PageApplication>();
            services.AddScoped<IPageRepository, PageRepository>();

            services.AddScoped<IPageCategoryApplication, PageCategoryApplication>();
            services.AddScoped<IPageCategoryRepository, PageCategoryRepository>();

            services.AddScoped<ICommentApplication, CommentApplication>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            
            services.AddScoped<ISlideApplication, SlideApplication>();
            services.AddScoped<ISlideRepository, SlideRepository>();

            services.AddScoped<ICategoryQuery, CategoryQuery>();
            services.AddScoped<IJobQuery, JobQuery>();
            services.AddScoped<ISlideQuery, SlideQuery>();
            
            services.AddScoped<IUserCardRepository, UserCardRepository>();

            services.AddSingleton<IAuthHelper, AuthHelper>();

            services.AddScoped<IUserGroupRepository, UserGroupRepository>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IJobPictureRepository, JobPictureRepository>();

            services.AddScoped<IPasargadService, PasargadService>();


            services.AddDbContext<OkapiaContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("OkapiaContext"));
                options.EnableSensitiveDataLogging();
            });

            services.AddDbContext<OkapiaViewContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("OkapiaViewContext"));
                options.EnableSensitiveDataLogging();
            });
        }
    }
}