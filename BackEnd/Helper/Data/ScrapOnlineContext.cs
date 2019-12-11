using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Data;

namespace WebApi2.Models
{
    public partial class ScrapOnlineContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public virtual DbSet<Clientorders> Clientorders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<ScrapCategories> ScrapCategories { get; set; }
        public ScrapOnlineContext()
        {
        }

        public ScrapOnlineContext(DbContextOptions<ScrapOnlineContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);
            builder.UseHiLo();

            builder.Entity<ApplicationUser>().ToTable("User", "master");
            builder.Entity<IdentityRole<long>>().ToTable("Role", "master");
            builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaim", "master");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaim", "master");

            builder.Entity<IdentityUserLogin<long>>().ToTable("UserLogin", "master");
            builder.Entity<IdentityUserRole<long>>().ToTable("UserRole", "master");
            builder.Entity<IdentityUserToken<long>>().ToTable("UserToken", "master");
            builder.Entity<Clientorders>(entity =>
            {
                entity.ToTable("clientorders", "master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("date");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Clientorders)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("clientorders_userid_fkey");
            });

            builder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.Orderdetailid)
                    .HasName("OrderDetails_pkey");

                entity.ToTable("OrderDetails", "master");

                entity.Property(e => e.Orderdetailid).HasColumnName("orderdetailid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("OrderDetails_categoryid_fkey");
            });

            builder.Entity<ScrapCategories>(entity =>
            {
                entity.ToTable("ScrapCategories", "master");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName).IsRequired();

                entity.Property(e => e.Unit).IsRequired();
            });

            // builder.Entity<User>(entity =>
            // {
            //     entity.ToTable("User", "master");

            //     entity.HasIndex(e => e.NormalizedEmail)
            //         .HasName("EmailIndex");

            //     entity.HasIndex(e => e.NormalizedUserName)
            //         .HasName("UserNameIndex")
            //         .IsUnique();

            //     entity.Property(e => e.Id).ValueGeneratedNever();

            //     entity.Property(e => e.Email).HasMaxLength(256);

            //     entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

            //     entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //     entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //     entity.Property(e => e.UserName).HasMaxLength(256);
            // });

            builder.HasSequence("EntityFrameworkHiLoSequence").IncrementsBy(10);

            OnModelCreatingPartial(builder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ScrapOnline;User Id=postgres;Password=admin;");
                }
            }
        }
    }
}