using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Kurs.Kurslar.Ders2
{
    public class ModelsData
    {
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Sku { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    public sealed class ProductWithCategoryDto
    {
        public string Name { get; init; } = default!;
        public string Kategori { get; init; } = default!;
        public decimal Price { get; init; }
    }

}
