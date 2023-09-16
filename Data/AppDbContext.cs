using LightHeight.Model;
using Microsoft.EntityFrameworkCore;

namespace LightHeight.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Book)                
            .WithMany()                         
            .HasForeignKey(o => o.BookId);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);


        //    modelBuilder.Entity<BookStore>().HasData(new BookStore
        //    {
        //        BookId = 1,
        //        Title = "Light House",
        //        Price = 15,
        //        Description = " Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem,sis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
        //    });
        //    modelBuilder.Entity<BookStore>().HasData(new BookStore
        //    {
        //        BookId = 2,
        //        Title = "Light House30",
        //        Price = 15,
        //        Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu.",
        //    });
        //}
    }
}
