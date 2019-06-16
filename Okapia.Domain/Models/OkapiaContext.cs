using Microsoft.EntityFrameworkCore;

namespace Okapia.Domain.Models
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
        //public virtual DbSet<JobPicture> JobPicture { get; set; }
        //public virtual DbSet<JobRelation> JobRelation { get; set; }
        //public virtual DbSet<Jobs> Jobs { get; set; }
        //public virtual DbSet<Page> Page { get; set; }
        //public virtual DbSet<PageCategory> PageCategory { get; set; }
        //public virtual DbSet<PageComments> PageComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Okapia;User ID=sa;Password=H@123456");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

        //    modelBuilder.Entity<Category>(entity =>
        //    {
        //        entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

        //        entity.Property(e => e.CategoryMetaDesccription).HasMaxLength(200);

        //        entity.Property(e => e.CategoryMetaTag).HasMaxLength(200);

        //        entity.Property(e => e.CategoryPageTittle).HasMaxLength(400);

        //        entity.Property(e => e.CategoryParentId).HasColumnName("CategoryParentID");

        //        entity.Property(e => e.CategorySeohead)
        //            .HasColumnName("CategorySEOHead")
        //            .HasMaxLength(400);

        //        entity.Property(e => e.CategorySmallDescription).HasMaxLength(1000);

        //        entity.Property(e => e.CategoryThumbPicUrl)
        //            .HasColumnName("CategoryThumbPicURL")
        //            .HasMaxLength(1000);

        //        entity.Property(e => e.CatgoryName).HasMaxLength(400);

        //        entity.Property(e => e.Job).HasMaxLength(10);

        //        entity.Property(e => e.JobLinkTitle).HasMaxLength(100);

        //        entity.Property(e => e.RegisteringEmployeeId).HasColumnName("RegisteringEmployeeID");
        //    });

        //    modelBuilder.Entity<JobPicture>(entity =>
        //    {
        //        entity.Property(e => e.JobPictureId).HasColumnName("JobPictureID");

        //        entity.Property(e => e.JobId).HasColumnName("JobID");

        //        entity.Property(e => e.JobPicturThumbUrl)
        //            .HasColumnName("JobPicturThumbURL")
        //            .HasMaxLength(400);

        //        entity.Property(e => e.JobPictureAlt).HasMaxLength(50);

        //        entity.Property(e => e.JobPictureSmallDescription).HasMaxLength(400);

        //        entity.Property(e => e.JobPictureTitle).HasMaxLength(100);

        //        entity.Property(e => e.JobPictureUrl)
        //            .HasColumnName("JobPictureURL")
        //            .HasMaxLength(400);

        //        entity.HasOne(d => d.Job)
        //            .WithMany(p => p.JobPicture)
        //            .HasForeignKey(d => d.JobId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_JobPicture_Jobs");
        //    });

        //    modelBuilder.Entity<JobRelation>(entity =>
        //    {
        //        entity.Property(e => e.JobRelationId).HasColumnName("JobRelationID");

        //        entity.Property(e => e.JobId).HasColumnName("JobID");

        //        entity.Property(e => e.RelatedId).HasColumnName("RelatedID");

        //        entity.HasOne(d => d.Job)
        //            .WithMany(p => p.JobRelationJob)
        //            .HasForeignKey(d => d.JobId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_JobRelation_Jobs");

        //        entity.HasOne(d => d.Related)
        //            .WithMany(p => p.JobRelationRelated)
        //            .HasForeignKey(d => d.RelatedId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_JobRelation_Jobs1");
        //    });

        //    modelBuilder.Entity<Jobs>(entity =>
        //    {
        //        entity.HasKey(e => e.JobId);

        //        entity.Property(e => e.JobId).HasColumnName("JobID");

        //        entity.Property(e => e.JobAccountNumber).HasMaxLength(400);

        //        entity.Property(e => e.JobAddress).HasMaxLength(1000);

        //        entity.Property(e => e.JobCanonicalAddress).HasMaxLength(300);

        //        entity.Property(e => e.JobCityId).HasColumnName("JobCityID");

        //        entity.Property(e => e.JobContactTitile).HasMaxLength(400);

        //        entity.Property(e => e.JobContractNumber).HasMaxLength(10);

        //        entity.Property(e => e.JobEmailAddress).HasMaxLength(200);

        //        entity.Property(e => e.JobManagerFirstName).HasMaxLength(60);

        //        entity.Property(e => e.JobManagerLastName).HasMaxLength(60);

        //        entity.Property(e => e.JobMap).HasMaxLength(1000);

        //        entity.Property(e => e.JobMetaDesccription).HasMaxLength(200);

        //        entity.Property(e => e.JobMetaTag).HasMaxLength(200);

        //        entity.Property(e => e.JobMobile1).HasMaxLength(20);

        //        entity.Property(e => e.JobMobile2).HasMaxLength(50);

        //        entity.Property(e => e.JobName)
        //            .IsRequired()
        //            .HasMaxLength(200);

        //        entity.Property(e => e.JobPageTittle).HasMaxLength(400);

        //        entity.Property(e => e.JobPosNameNumber).HasMaxLength(400);

        //        entity.Property(e => e.JobProvienceId).HasColumnName("JobProvienceID");

        //        entity.Property(e => e.JobRemoved301InsteadUrl)
        //            .HasColumnName("JobRemoved301InsteadURL")
        //            .HasMaxLength(200);

        //        entity.Property(e => e.JobSeohead)
        //            .HasColumnName("JobSEOHead")
        //            .HasMaxLength(400);

        //        entity.Property(e => e.JobSlug)
        //            .IsRequired()
        //            .HasMaxLength(200);

        //        entity.Property(e => e.JobSmallDescription).HasMaxLength(2000);

        //        entity.Property(e => e.JobTel1).HasMaxLength(20);

        //        entity.Property(e => e.JobTel2).HasMaxLength(20);

        //        entity.Property(e => e.MarketerId).HasColumnName("MarketerID");

        //        entity.Property(e => e.RegisteringEmployerId).HasColumnName("RegisteringEmployerID");
        //    });

        //    modelBuilder.Entity<Page>(entity =>
        //    {
        //        entity.Property(e => e.PageId).HasColumnName("PageID");

        //        entity.Property(e => e.PageCanonicalAddress).HasMaxLength(300);

        //        entity.Property(e => e.PageCategoryId).HasColumnName("PageCategoryID");

        //        entity.Property(e => e.PageCategoryMetaDesccription).HasMaxLength(200);

        //        entity.Property(e => e.PageCategoryMetaTag).HasMaxLength(200);

        //        entity.Property(e => e.PageCategoryRemoved301InsteadUrl)
        //            .HasColumnName("PageCategoryRemoved301InsteadURL")
        //            .HasMaxLength(200);

        //        entity.Property(e => e.PageCategorySeohead)
        //            .HasColumnName("PageCategorySEOHead")
        //            .HasMaxLength(400);

        //        entity.Property(e => e.PageSlug)
        //            .IsRequired()
        //            .HasMaxLength(200);

        //        entity.Property(e => e.PageSmallDescription).HasMaxLength(2000);

        //        entity.Property(e => e.PageTittle)
        //            .IsRequired()
        //            .HasMaxLength(400);

        //        entity.Property(e => e.RegisteringEmployeeId).HasColumnName("RegisteringEmployeeID");

        //        entity.Property(e => e.RegistrationDate)
        //            .HasColumnType("datetime")
        //            .HasDefaultValueSql("(getdate())");

        //        entity.HasOne(d => d.PageCategory)
        //            .WithMany(p => p.Page)
        //            .HasForeignKey(d => d.PageCategoryId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Page_PageCategory");
        //    });

        //    modelBuilder.Entity<PageCategory>(entity =>
        //    {
        //        entity.Property(e => e.PageCategoryId).HasColumnName("PageCategoryID");

        //        entity.Property(e => e.PageCanonicalAddress).HasMaxLength(300);

        //        entity.Property(e => e.PageCategoryLinkTooTip).HasMaxLength(100);

        //        entity.Property(e => e.PageCategoryMetaDesccription).HasMaxLength(200);

        //        entity.Property(e => e.PageCategoryMetaTag).HasMaxLength(200);

        //        entity.Property(e => e.PageCategoryName).HasMaxLength(50);

        //        entity.Property(e => e.PageCategoryPageTittle).HasMaxLength(400);

        //        entity.Property(e => e.PageCategoryParentId).HasColumnName("PageCategoryParentID");

        //        entity.Property(e => e.PageCategoryRemoved301InsteadUrl)
        //            .HasColumnName("PageCategoryRemoved301InsteadURL")
        //            .HasMaxLength(200);

        //        entity.Property(e => e.PageCategorySeohead)
        //            .HasColumnName("PageCategorySEOHead")
        //            .HasMaxLength(400);

        //        entity.Property(e => e.PageCategorySlug).HasMaxLength(200);

        //        entity.Property(e => e.PageCategorySmallPictutre).HasMaxLength(400);

        //        entity.Property(e => e.PageCategorySmallPictutreAlt).HasMaxLength(400);

        //        entity.HasOne(d => d.PageCategoryParent)
        //            .WithMany(p => p.InversePageCategoryParent)
        //            .HasForeignKey(d => d.PageCategoryParentId)
        //            .HasConstraintName("FK_PageCategory_PageCategory");
        //    });

        //    modelBuilder.Entity<PageComments>(entity =>
        //    {
        //        entity.HasKey(e => e.PageCommentId);

        //        entity.Property(e => e.PageCommentId)
        //            .HasColumnName("PageCommentID")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.CommentDate)
        //            .HasColumnType("datetime")
        //            .HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.CommentPageUrl)
        //            .HasColumnName("CommentPageURL")
        //            .HasMaxLength(200);

        //        entity.Property(e => e.CommentTitle).HasMaxLength(200);

        //        entity.Property(e => e.CommentUserId).HasColumnName("CommentUserID");

        //        entity.Property(e => e.CommnetText).HasMaxLength(4000);

        //        entity.Property(e => e.PageCommentConfiringUserId).HasColumnName("PageCommentConfiringUserID");

        //        entity.Property(e => e.PageCommentConfirmDate).HasColumnType("datetime");

        //        entity.Property(e => e.PageId).HasColumnName("PageID");

        //        entity.HasOne(d => d.Page)
        //            .WithMany(p => p.PageComments)
        //            .HasForeignKey(d => d.PageId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_PageComments_Page");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}