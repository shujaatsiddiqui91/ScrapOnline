using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi2.Models
{
    public partial class ScrapOnlineContext 
    {
//         public ScrapOnlineContext()
//         {
//         }

//         public ScrapOnlineContext(DbContextOptions<ScrapOnlineContext> options)
//             : base(options)
//         {
//         }

//         public virtual DbSet<OrderDetails> OrderDetails { get; set; }

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
//             modelBuilder.Entity<OrderDetails>(entity =>
//             {
//                 entity.HasKey(e => e.Orderdetailid)
//                     .HasName("OrderDetails_pkey");

//                 entity.ToTable("OrderDetails", "master");

//                 entity.Property(e => e.Orderdetailid).HasColumnName("orderdetailid");

//                 entity.Property(e => e.Categoryid).HasColumnName("categoryid");

//                 entity.Property(e => e.Quantity).HasColumnName("quantity");
//             });

//             modelBuilder.HasSequence("EntityFrameworkHiLoSequence").IncrementsBy(10);

//             OnModelCreatingPartial(modelBuilder);
//         }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
