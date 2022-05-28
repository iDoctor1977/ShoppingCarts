using System;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCarts.StorageRoom.Data.Entities
{
    public class ProjectDbContext : DbContext
    {
        private readonly string _dbName;
        private readonly string _connectionStringName;

        public ProjectDbContext()
        {
            _dbName = "ProjectNameDB";
            _connectionStringName = CreateConnectionStringPath();
        }

        public ProjectDbContext(string dbName)
        {
            _dbName = dbName;
            _connectionStringName = CreateConnectionStringPath();
        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        private string CreateConnectionStringPath() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return $"Data Source={path}{System.IO.Path.DirectorySeparatorChar}" + _dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseInMemoryDatabase(_dbName);
            //optionsBuilder.UseSqlServer(_connectionStringName);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<CartItem>().ToTable("ShoppingCartItems ");
            modelBuilder.Entity<Category>().ToTable("Categories ");
            modelBuilder.Entity<Product>().ToTable("Products ");
        }
    }
}
