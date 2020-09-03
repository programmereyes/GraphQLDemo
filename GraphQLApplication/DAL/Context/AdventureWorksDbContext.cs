using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class AdventureWorksDbContext:DbContext
    {

        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> contextOptions)
            :base(contextOptions)
        {
         
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderDetail>().HasNoKey().HasOne(x => x.OrderDetailOrderNavigation).WithOne(x => x.OrderOrderDetailNavigation)
            //      .HasForeignKey<OrderDetail>(x => x.OrderId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
    }
}
