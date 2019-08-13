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

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<JobPicture> JobPicture { get; set; }
        public virtual DbSet<JobRelation> JobRelation { get; set; }
        public virtual DbSet<JobTransactions> JobTransactions { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Modal> Modals { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PageCategory> PageCategory { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCard> UserCards { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Controller> Controllers { get; set; }
        public DbSet<EmployeeController> EmployeeControllers { get; set; }
        public DbSet<JobRequest> JobRequests { get; set; }
        public DbSet<Marketer> Marketers { get; set; }

        public DbSet<Slide> Slides { get; set; }
        //public DbSet<UserGroup> UserGroups { get; set; }

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