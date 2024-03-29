﻿using EcommerceApp.Models;
using EcommerceAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.DataAccess
{
    public class MainDbContext :DbContext 
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
