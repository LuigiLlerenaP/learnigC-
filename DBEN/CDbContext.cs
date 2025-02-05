using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBEN;

public partial class CDbContext : DbContext
{
    public CDbContext()
    {
    }

    public CDbContext(DbContextOptions<CDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Movement> Movements { get; set; }

    public virtual DbSet<TransactionCatalog> TransactionCatalogs { get; set; }

    public virtual DbSet<UserFinance> UserFinances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LUIGI;Database=c_db;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__budget__3213E83F4F0F31E1");

            entity.ToTable("budget");

            entity.HasIndex(e => new { e.UserId, e.CategoryId }, "budget_index_7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BudgetName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("budget_name");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.TotalBudget)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_budget");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ValidUntil).HasColumnName("valid_until");

            entity.HasOne(d => d.Category).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__budget__category__02084FDA");

            entity.HasOne(d => d.User).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__budget__user_id__01142BA1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83FCB2D8E25");

            entity.ToTable("category");

            entity.HasIndex(e => e.Name, "UQ__category__72E12F1B1D5FE0FB").IsUnique();

            entity.HasIndex(e => e.ParentCategoryId, "category_index_2");

            entity.HasIndex(e => new { e.ParentCategoryId, e.Name }, "category_index_3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK__category__parent__7D439ABD");
        });

        modelBuilder.Entity<Movement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__movement__3213E83FCCEBB274");

            entity.ToTable("movement");

            entity.HasIndex(e => new { e.UserId, e.MovementDate }, "movement_index_6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MovementDate).HasColumnName("movement_date");
            entity.Property(e => e.TransactionCatalogId).HasColumnName("transaction_catalog_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ValueMovement)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("value_movement");

            entity.HasOne(d => d.TransactionCatalog).WithMany(p => p.Movements)
                .HasForeignKey(d => d.TransactionCatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__movement__transa__00200768");

            entity.HasOne(d => d.User).WithMany(p => p.Movements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__movement__user_i__7F2BE32F");
        });

        modelBuilder.Entity<TransactionCatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83FC1E6098C");

            entity.ToTable("transaction_catalog");

            entity.HasIndex(e => e.Name, "UQ__transact__72E12F1B5C2022DA").IsUnique();

            entity.HasIndex(e => e.CategoryId, "transaction_catalog_index_4");

            entity.HasIndex(e => new { e.TransactionType, e.CategoryId }, "transaction_catalog_index_5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type");

            entity.HasOne(d => d.Category).WithMany(p => p.TransactionCatalogs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transacti__categ__7E37BEF6");
        });

        modelBuilder.Entity<UserFinance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_fin__3213E83F6ECDA2C6");

            entity.ToTable("user_finance");

            entity.HasIndex(e => e.UserName, "UQ__user_fin__7C9273C4030FDAAB").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__user_fin__AB6E6164000C77AA").IsUnique();

            entity.HasIndex(e => e.UserName, "user_finance_index_0");

            entity.HasIndex(e => e.Email, "user_finance_index_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.InitialBudget)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("initial_budget");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
