using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class user_7_20P3Context : DbContext
    {
        public static user_7_20P3Context Context { get; } = new user_7_20P3Context();
        public user_7_20P3Context()
        {
        }

        public user_7_20P3Context(DbContextOptions<user_7_20P3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderproduct> Orderproducts { get; set; }
        public virtual DbSet<Ordersstatus> Ordersstatuses { get; set; }
        public virtual DbSet<Pickpoint> Pickpoints { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;port=3306;user=root;database=user_7_20P3;password=kolyan28", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.Property(e => e.NameCategory).HasColumnType("text");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.HasKey(e => e.IdManufacture)
                    .HasName("PRIMARY");

                entity.ToTable("manufacture");

                entity.Property(e => e.NameManufacture).HasColumnType("text");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.OrderPickupPoint, "pick_idx");

                entity.HasIndex(e => e.OrderStatus, "status_idx");

                entity.HasIndex(e => e.Client, "user_idx");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderDeliveryDate).HasColumnType("date");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Client)
                    .HasConstraintName("user");

                entity.HasOne(d => d.OrderPickupPointNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderPickupPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pick");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("status");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("orderproduct");

                entity.HasIndex(e => e.ProductArticleNumber, "ProductArticleNumber");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductArticleNumber)
                    .HasMaxLength(100)
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderproduct_ibfk_1");

                entity.HasOne(d => d.ProductArticleNumberNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.ProductArticleNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderproduct_ibfk_2");
            });

            modelBuilder.Entity<Ordersstatus>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId)
                    .HasName("PRIMARY");

                entity.ToTable("ordersstatus");

                entity.Property(e => e.NameStatus).HasColumnType("text");
            });

            modelBuilder.Entity<Pickpoint>(entity =>
            {
                entity.ToTable("pickpoint");

                entity.Property(e => e.City).HasColumnType("text");

                entity.Property(e => e.Street).HasColumnType("text");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductArticleNumber)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.ProductCategory, "cat_idx");

                entity.HasIndex(e => e.ProductManufacturer, "manu_idx");

                entity.HasIndex(e => e.Supplier, "supplier_idx");

                entity.Property(e => e.ProductArticleNumber)
                    .HasMaxLength(100)
                    .HasComment("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MaxDiscount).HasPrecision(19, 2);

                entity.Property(e => e.ProductCost).HasPrecision(19, 2);

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ProductDiscountAmount).HasPrecision(19, 2);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ProductPhoto)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Unit).HasColumnType("text");

                entity.HasOne(d => d.ProductCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cat");

                entity.HasOne(d => d.ProductManufacturerNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductManufacturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("manu");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Supplier)
                    .HasConstraintName("supplier");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier)
                    .HasName("PRIMARY");

                entity.ToTable("supplier");

                entity.Property(e => e.NameSupplier).HasColumnType("text");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserRole, "UserRole");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserPatronymic)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
