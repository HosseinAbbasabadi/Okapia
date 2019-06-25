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

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<JobPicture> JobPicture { get; set; }
        public virtual DbSet<JobRelation> JobRelation { get; set; }
        public virtual DbSet<JobTransactions> JobTransactions { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Modals> Modals { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PageCategory> PageCategory { get; set; }
        public virtual DbSet<PageComments> PageComments { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new GroupMapping());
            modelBuilder.ApplyConfiguration(new JobTransactionMapping());
            modelBuilder.ApplyConfiguration(new JobMapping());
            modelBuilder.ApplyConfiguration(new ModalMapping());
            modelBuilder.ApplyConfiguration(new JobPictureMapping());
            modelBuilder.ApplyConfiguration(new JobRelationMapping());
            modelBuilder.ApplyConfiguration(new ModalMapping());
            modelBuilder.ApplyConfiguration(new PageMapping());
            modelBuilder.ApplyConfiguration(new PageCategoryMapping());
            modelBuilder.ApplyConfiguration(new PageCommentMapping());
            OnModelCreatingPartial(modelBuilder);
        }

        private static void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}