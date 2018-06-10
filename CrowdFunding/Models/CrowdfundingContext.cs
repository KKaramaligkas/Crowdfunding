using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrowdFunding.Models
{
    public partial class CrowdfundingContext : DbContext
    {
        public CrowdfundingContext()
        {
        }

        public CrowdfundingContext(DbContextOptions<CrowdfundingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Backers> Backers { get; set; }
        public virtual DbSet<Benefits> Benefits { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<ProjecBacker> ProjecBacker { get; set; }
        public virtual DbSet<ProjectCreator> ProjectCreator { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ReachGoal> ReachGoal { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Crowdfunding;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backers>(entity =>
            {
                entity.HasKey(e => e.BackerId);

                entity.Property(e => e.BackerId).ValueGeneratedNever();

                entity.Property(e => e.Fund).HasColumnType("money");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Backers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Backers_UserId");
            });

            modelBuilder.Entity<Benefits>(entity =>
            {
                entity.Property(e => e.BenefitsId).ValueGeneratedNever();

                entity.Property(e => e.BenefitName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Benefits)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectId");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.Property(e => e.ProgressId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ProjecBacker>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.BackerId });

                entity.HasOne(d => d.Backer)
                    .WithMany(p => p.ProjecBacker)
                    .HasForeignKey(d => d.BackerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectBacker_Backers_BackerId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjecBacker)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectBacker_Projects_ProjectId");
            });

            modelBuilder.Entity<ProjectCreator>(entity =>
            {
                entity.Property(e => e.ProjectCreatorId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectCreator)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCreator_UserId");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.AskedFund).HasColumnType("money");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Url)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryId");

                entity.HasOne(d => d.ProjectCreator)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectCreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectCreatorId");
            });

            modelBuilder.Entity<ReachGoal>(entity =>
            {
                entity.Property(e => e.ReachGoalId).ValueGeneratedNever();

                entity.Property(e => e.Flag).HasColumnName("flag");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.Email)
                    .HasName("Users_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Mobilephone)
                    .HasName("Users_Mobilephone")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Mobilephone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
