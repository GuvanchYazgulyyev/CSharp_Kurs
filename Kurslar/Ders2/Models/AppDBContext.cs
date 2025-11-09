using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Kurs.Kurslar.Ders2.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext (DbContextOptions<AppDBContext> options): base(options) { }

        public DbSet<Product> Products=> Set<Product>();
        public DbSet<Category> Categories=> Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(z =>
            {
                z.Property(f=>f.Name).IsRequired().HasMaxLength(200);
              //  z.Property(r => r.Price).HasColumnType("decimal(18,2)");
                z.HasOne(f=>f.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(l=>l.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(z =>
            {
                z.Property(w => w.Name).IsRequired().HasMaxLength(150);
            });

        }
    }
}
