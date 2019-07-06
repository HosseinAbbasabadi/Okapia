using Microsoft.EntityFrameworkCore;
using Okapia.Domain;
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
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<JobPicture> JobPicture { get; set; }
        public virtual DbSet<JobRelation> JobRelation { get; set; }
        public virtual DbSet<JobTransactions> JobTransactions { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Modals> Modals { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PageCategory> PageCategory { get; set; }
        public virtual DbSet<PageComments> PageComments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<AuthInfo> AuthInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // job mapping
            modelBuilder.ApplyConfiguration(new JobTransactionMapping());
            modelBuilder.ApplyConfiguration(new JobMapping());
            modelBuilder.ApplyConfiguration(new JobPictureMapping());
            modelBuilder.ApplyConfiguration(new JobRelationMapping());

            // page mapping
            modelBuilder.ApplyConfiguration(new PageMapping());
            modelBuilder.ApplyConfiguration(new PageCategoryMapping());
            modelBuilder.ApplyConfiguration(new PageCommentMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());

            // user mapping
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new GroupMapping());

            // modal mapping
            modelBuilder.ApplyConfiguration(new ModalMapping());

            // province mapping
            modelBuilder.ApplyConfiguration(new ProvinceMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new DistrictMapping());
            modelBuilder.ApplyConfiguration(new NeighborhoodMapping());
            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("JobSeq", schema: "shared")
                .StartsAt(1)
                .IncrementsBy(1);
            base.OnModelCreating(modelBuilder);
        }
    }
}