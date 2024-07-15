using Lesson_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson_3.Data
{
	public class StorageContext : DbContext
	{
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<ProductGroup> ProductGroups { get; set; }
		public virtual DbSet<Storage> Storages { get; set; }

		public StorageContext(DbContextOptions<StorageContext> dbContext) : base(dbContext) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductGroup>(entity =>
			{
				entity.HasKey(pg => pg.Id).HasName("product_group_pk");
				entity.ToTable("category");
				entity.Property(pg => pg.Name).HasColumnName("name").HasMaxLength(255);
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasKey(p => p.Id).HasName("product_pk");
				entity.Property(p => p.Name).HasColumnName("name").HasMaxLength(255);
				entity.HasOne(p => p.ProductGroup).WithMany(pg => pg.Products).HasForeignKey(p => p.ProductGroupId);
			});

			modelBuilder.Entity<Storage>(entity =>
			{
				entity.HasKey(s => s.Id).HasName("storage_pk");
				entity.HasOne(s => s.Product).WithMany(p => p.Storages).HasForeignKey(s => s.ProductId);
			});
		}
	}
}
