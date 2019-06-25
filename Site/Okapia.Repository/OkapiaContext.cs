using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Okapia.Repository.Mappings;

namespace Okapia.Domain
{
    public partial class OkapiaContext : DbContext
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Okapia;Persist Security Info=True;User ID=sa;Password=H@123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<JobPicture>(entity =>
            {
                
            });

            modelBuilder.ApplyConfiguration(new JobRelationMapping());

            modelBuilder.ApplyConfiguration(new ModalMapping());

            modelBuilder.ApplyConfiguration(new PageMapping());

            modelBuilder.ApplyConfiguration(new PageCategoryMapping());

            modelBuilder.ApplyConfiguration(new PageCommentMapping());

            OnModelCreatingPartial(modelBuilder);
        }

        void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}