using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi2.Models
{
    public partial class ScrapOnlineContext 
    {
        // public ScrapOnlineContext()
        // {
        // }

//         public ScrapOnlineContext(DbContextOptions<ScrapOnlineContext> options)
//             : base(options)
//         {
//         }

        public virtual DbSet<Clientorders> Clientorders { get; set; }
        public virtual DbSet<ScrapCategories> ScrapCategories { get; set; }
//         public virtual DbSet<User> User { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ScrapOnline;User Id=postgres;Password=admin;");
//             }
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<Clientorders>(entity =>
//             {
//                 entity.ToTable("clientorders", "master");

//                 entity.Property(e => e.Id).HasColumnName("id");

//                 entity.Property(e => e.Createdate)
//                     .HasColumnName("createdate")
//                     .HasColumnType("date");

//                 entity.Property(e => e.Orderid).HasColumnName("orderid");

//                 entity.Property(e => e.Userid).HasColumnName("userid");

//                 entity.HasOne(d => d.User)
//                     .WithMany(p => p.Clientorders)
//                     .HasForeignKey(d => d.Userid)
//                     .HasConstraintName("clientorders_userid_fkey");
//             });

//             modelBuilder.Entity<ScrapCategories>(entity =>
//             {
//                 entity.ToTable("ScrapCategories", "master");

//                 entity.Property(e => e.Id)
//                     .HasColumnName("id")
//                     .ValueGeneratedNever();

//                 entity.Property(e => e.CategoryName).IsRequired();

//                 entity.Property(e => e.Unit).IsRequired();
//             });

//             modelBuilder.Entity<User>(entity =>
//             {
//                 entity.ToTable("User", "master");

//                 entity.HasIndex(e => e.NormalizedEmail)
//                     .HasName("EmailIndex");

//                 entity.HasIndex(e => e.NormalizedUserName)
//                     .HasName("UserNameIndex")
//                     .IsUnique();

//                 entity.Property(e => e.Id).ValueGeneratedNever();

//                 entity.Property(e => e.Email).HasMaxLength(256);

//                 entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

//                 entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

//                 entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

//                 entity.Property(e => e.UserName).HasMaxLength(256);
//             });

//             modelBuilder.HasSequence("EntityFrameworkHiLoSequence").IncrementsBy(10);

//             OnModelCreatingPartial(modelBuilder);
//         }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
