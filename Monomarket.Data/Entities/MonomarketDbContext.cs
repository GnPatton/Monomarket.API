using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Monomarket.Data.Entities
{
    public partial class MonomarketDbContext : DbContext
    {
        public MonomarketDbContext()
        {
        }

        public MonomarketDbContext(DbContextOptions<MonomarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Migration> Migrations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=monomarket;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("migration");

                entity.Property(e => e.IdMigration)
                    .HasColumnName("id_migration")
                    .HasDefaultValueSql("nextval('migration_id_migration'::regclass)");

                entity.Property(e => e.Major).HasColumnName("major");

                entity.Property(e => e.Minor).HasColumnName("minor");

                entity.Property(e => e.Source)
                    .HasMaxLength(150)
                    .HasColumnName("source");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("city");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("district");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasKey(e => e.UserCredentialsId)
                    .HasName("pk_user_credentials");

                entity.ToTable("user_credentials");

                entity.HasIndex(e => e.UserId, "user_credentials__idx")
                    .IsUnique();

                entity.Property(e => e.UserCredentialsId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_credentials_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserCredential)
                    .HasForeignKey<UserCredential>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_credentials_user");
            });

            modelBuilder.HasSequence("migration_id_migration").HasMin(0);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
