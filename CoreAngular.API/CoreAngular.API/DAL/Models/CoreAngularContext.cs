using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CoreAngular.API.DAL.Models
{
    public partial class CoreAngularContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public CoreAngularContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CoreAngularContext(DbContextOptions<CoreAngularContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderPackage> OrderPackage { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Timeline> Timeline { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CoreAngular"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ReceivingUserId).HasColumnName("ReceivingUser_Id");

                entity.Property(e => e.SendingUserId).HasColumnName("SendingUser_Id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OfferingUserId).HasColumnName("OfferingUser_Id");

                entity.Property(e => e.PriceId).HasColumnName("Price_Id");

                entity.Property(e => e.RequestingUserId).HasColumnName("RequestingUser_Id");
            });

            modelBuilder.Entity<OrderPackage>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PriceTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Price1)
                    .HasColumnName("Price")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Timeline>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
