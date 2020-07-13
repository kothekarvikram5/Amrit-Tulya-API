using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Amrit.Tulya.Models
{
    public partial class TeaShopContext : DbContext
    {
        public TeaShopContext()
        {
        }

        public TeaShopContext(DbContextOptions<TeaShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TeaInventory> TeaInventory { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\db;Initial Catalog=TeaShop;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeaInventory>(entity =>
            {
                entity.HasKey(e => e.TeaId)
                    .HasName("PK__Tea_Inve__16876EE263C641E4");

                entity.ToTable("Tea_Inventory");

                entity.Property(e => e.TeaId).HasColumnName("Tea_ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeaDescription).HasColumnName("Tea_Description");

                entity.Property(e => e.TeaImagePath).HasColumnName("Tea_Image_Path");

                entity.Property(e => e.TeaName)
                    .IsRequired()
                    .HasColumnName("Tea_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TeaPrice)
                    .HasColumnName("Tea_Price")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
