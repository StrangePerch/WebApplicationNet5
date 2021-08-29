using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationNet5.Entities.Car;
using WebApplicationNet5.Entities.Catalog;
using WebApplicationNet5.Entities.Post;
using WebApplicationNet5.Entities.Product;
using WebApplicationNet5.Entities.School;
using WebApplicationNet5.Models;

namespace WebApplicationNet5.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUser>
    {
        //
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

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

        public DbSet<Drivetrain> Drivetrains { get; set; }

        // 
        //Catalog
        public DbSet<Catalog> Catalogs { get; set; }

        //
        //School
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .UsingEntity(j => j.ToTable("PivotProductTag"));

            // .UsingEntity<Dictionary<string, object>>(
            // "PostTag",
            // j => j
            //     .HasOne<Tag>()
            //     .WithMany()
            //     .HasForeignKey("TagId")
            //     .HasConstraintName("FK_PostTag_Tags_TagId")
            //     .OnDelete(DeleteBehavior.Cascade),
            // j => j
            //     .HasOne<Post>()
            //     .WithMany()
            //     .HasForeignKey("PostId")
            //     .HasConstraintName("FK_PostTag_Posts_PostId")
            //     .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}