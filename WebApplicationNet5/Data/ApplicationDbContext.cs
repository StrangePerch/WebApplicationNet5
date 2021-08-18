using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationNet5.Entities.Car;
using WebApplicationNet5.Entities.Post;
using WebApplicationNet5.Entities.Product;

namespace WebApplicationNet5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Posts
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //
        //Products
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        //
        //Cars
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Drivetrain> Drivetrains {get; set;}
        //
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}