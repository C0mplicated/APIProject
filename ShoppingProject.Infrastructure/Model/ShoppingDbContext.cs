using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoppingProject.Core.Model;

public partial class ShoppingDbContext : DbContext
{
    public ShoppingDbContext()
    {
    }

    public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AvailableSize> AvailableSizes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-LBAL79H\\SQLEXPRESS;database=ShoppingDB;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvailableSize>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__availabl__0DCACE316D318671");

            entity.ToTable("availableSizes");

            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SizeValue)
                .HasMaxLength(50)
                .HasColumnName("size_value");

            entity.HasOne(d => d.Product).WithMany(p => p.AvailableSizes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__available__produ__398D8EEE");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83FD7CE7118");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrencyFormat)
                .HasMaxLength(10)
                .HasColumnName("currencyFormat");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(10)
                .HasColumnName("currencyId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Installments).HasColumnName("installments");
            entity.Property(e => e.IsFreeShipping).HasColumnName("isFreeShipping");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Style)
                .HasMaxLength(50)
                .HasColumnName("style");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CCDD56ADC");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
