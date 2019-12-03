using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Data;

namespace WebApi2.Models
{
    public partial class ScrapOnlineContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
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

            builder.Entity<ScrapCategories>(entity =>
                {
                    entity.ToTable("ScrapCategories", "master");

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .ValueGeneratedNever();

                    entity.Property(e => e.CategoryName).IsRequired();

                    entity.Property(e => e.Unit).IsRequired();
                });
        }
    }
}