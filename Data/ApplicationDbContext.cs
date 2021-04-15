using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StuffAndThings.Models;

namespace StuffAndThings.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StuffAndThings.Models.ProductModel> Products { get; set; }
        public DbSet<StuffAndThings.Models.SkuModel> Skus { get; set; }
    }
}
