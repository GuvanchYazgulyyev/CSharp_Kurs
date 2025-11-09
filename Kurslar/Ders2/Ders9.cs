using CSharp_Kurs.Kurslar.Ders2.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CSharp_Kurs.Kurslar.Ders2
{
    public class Ders9
    {
        public static async Task OperationLinq()
        {
            using var db = new AppDBContext();
            var q = db.Products
                .Join(db.Categories,
                x => x.CategoryId,
                f => f.Id,
                (x, f) => new ProductWithCategoryDto
                {
                    Name = x.Name,
                    Kategori = f.Name,
                    Price = x.Price
                })
                .AsNoTracking()
                .ToList();

            // Async
            var q2 = await db.Products
                .Join(db.Categories,
                x => x.CategoryId,
                f => f.Id,
                (x, f) => new ProductWithCategoryDto
                {
                    Name = x.Name,
                    Kategori = f.Name,
                    Price = x.Price
                })
                .AsNoTracking()
                .ToListAsync();

            // Arassa Yagdayy.
            var getData = db.Products
                .Select(f => new ProductWithCategoryDto
                {
                    Name = f.Name,
                    Kategori = f.Category.Name,
                    Price = f.Price
                })
                .AsNoTracking()
                .ToListAsync();

            // Union, Intersect,  District By
            var kampanyaSku = new[] { "USE001", "DATA4410" };
            var stokSku = db.Products.Select(f => f.Sku);

            var orta = stokSku.Intersect(kampanyaSku);// 2 tablissalarda da data bar bolsa. 
            var dis=stokSku.Except(kampanyaSku); // Stokda bolup yöne kampanyada bolmayanlary getir. 
        }
    }
}
