using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Repository.Mappings;

namespace Okapia.Repository
{
    public class OkapiaContext : DbContext
    {
        public OkapiaContext()
        {
        }

        public OkapiaContext(DbContextOptions<OkapiaContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<JobPicture> JobPicture { get; set; }
        public DbSet<JobRelation> JobRelation { get; set; }
        public DbSet<JobTransaction> JobTransactions { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Modal> Modals { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageCategory> PageCategory { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Controller> Controllers { get; set; }
        public DbSet<EmployeeController> EmployeeControllers { get; set; }
        public DbSet<JobRequest> JobRequests { get; set; }
        public DbSet<Marketer> Marketers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Link> Links { get; set; }
        //public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // job mapping
            modelBuilder.ApplyConfiguration(new JobTransactionMapping());
            modelBuilder.ApplyConfiguration(new JobMapping());
            modelBuilder.ApplyConfiguration(new JobPictureMapping());
            modelBuilder.ApplyConfiguration(new JobRelationMapping());
            modelBuilder.ApplyConfiguration(new JobRequestMapping());

            // page mapping
            modelBuilder.ApplyConfiguration(new PageMapping());
            modelBuilder.ApplyConfiguration(new PageCategoryMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());

            // user mapping
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserCardMapping());
            modelBuilder.ApplyConfiguration(new GroupMapping());
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
            modelBuilder.ApplyConfiguration(new UserGroupMapping());
            modelBuilder.ApplyConfiguration(new UserTransactionMapping());

            // modal mapping
            modelBuilder.ApplyConfiguration(new ModalMapping());

            // slide mapping
            modelBuilder.ApplyConfiguration(new SlideMapping());

            // province mapping
            modelBuilder.ApplyConfiguration(new ProvinceMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new DistrictMapping());
            modelBuilder.ApplyConfiguration(new NeighborhoodMapping());

            modelBuilder.ApplyConfiguration(new EmployeeControllerMapping());
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new MarketerMapping());

            modelBuilder.ApplyConfiguration(new SettingMapping());
            modelBuilder.ApplyConfiguration(new LinkMapping());
            modelBuilder.ApplyConfiguration(new ContactUsMapping());

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>("AccountReferenceIdSeq")
                .StartsAt(3000)
                .IncrementsBy(1);
            modelBuilder.HasSequence<long>("TrackingNumberSeq")
                .StartsAt(2000)
                .IncrementsBy(1);
            base.OnModelCreating(modelBuilder);
        }
    }
}