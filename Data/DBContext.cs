using Microsoft.EntityFrameworkCore;
using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StuffAndThings;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SkuEntity> Skus { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SkuStocksEntity> Stocks { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<ShowcaseEntity> Showcases { get; set; }
        public DbSet<ShowcaseItemsEntity> ShowcaseItems { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<OrderItemsEntity> OrderItems { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<PaymentEntity> Payment { get; set; }
    }
}
