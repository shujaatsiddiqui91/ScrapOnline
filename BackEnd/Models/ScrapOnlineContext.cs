using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi2.Data;

namespace WebApi2.Models
{
    public partial class ScrapOnlineContext
    {

        public ScrapOnlineContext(DbContextOptions<ScrapOnlineContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ScrapCategories> ScrapCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ScrapOnline;User Id=postgres;Password=admin;");
            }
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {

        //     modelBuilder.Entity<ScrapCategories>(entity =>
        //     {
        //         entity.ToTable("ScrapCategories", "master");

        //         entity.Property(e => e.Id)
        //             .HasColumnName("id")
        //             .ValueGeneratedNever();

        //         entity.Property(e => e.CategoryName).IsRequired();

        //         entity.Property(e => e.Unit).IsRequired();
        //     });
        // }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
