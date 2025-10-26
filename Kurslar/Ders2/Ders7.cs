using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Kurs.Kurslar.Ders2
{
    public class Ders7
    {
        // LINQ (Language Integrated Query) Mysaly
        // Where 
        // Select
        // OrderBy / ThenBy
        // GroupBy
        // join 
        // Distinct
        // Any/All
        // First/FirstOrDefault
        // First / Single / SingleOrDefault
        // Count / Sum / Average / Min / Max
        // SelectMany

        // Example Method
        public record Category(int Id, string Name);
        public record Product(int Id, string Name, decimal Price, int Stock, int CategoryId);

        public record OrderProsec(int ProductId, int Quantity, decimal unitPrice);

        public record Order(int Id, string Customer, List<OrderProsec> OrderProsecs);
        #region ders 7
        public static void Operations()
        {
            var categorys = new List<Category>
            {
                new(1,"Klawatura"), new(2,"Laptop"), new(3,"Ekran.")
            };

            var products = new List<Product>
            {
                new(1,"Xiomi",300m,50,2),
                new(2,"Dell",700m,50,2),
                new(3,"Lenova",500m,50,2),
                new(4,"Casper",400m,50,2),
                new(5,"Toshiba",400m,50,2),
                new(6,"Microsoft",100m,50,1),
                new(7,"Dell",300m,50,3),
            };

            var orders = new List<Order>
            {
                new(101, "Muhammet", new(){new (2,5,700m),new (6,5,100m)}),
                new(101, "Guwanç", new(){new (2,5,700m),new (6,5,100m)}),
                new(101, "Jeren", new(){new (1,5,33m),new (6,5,100m)})
            };

            // Filtreleme. Where we Sanyny al .  
            var stoklaryBolan = products.Where(x => x.Stock > 0).Count();
            var controlData = products.Where(f => f.CategoryId == 2 && f.Price >= 350m).Count();

            // Filtreleme. Where we List Görnüşün dee ber. 
            var controlStock = products.Where(x => x.Stock > 0).ToList();
            var filterData = products.Where(f => f.CategoryId == 2 && f.Price >= 350m).ToList();

            // Select (anonim type / DTO)
            var productSummery = products.Select(d => new { d.Name, d.Price, IsStock = d.Stock > 0 ? "Bar" : "Yok" }).ToList();
            var justname = products.Select(j => j.Name).ToList();

            // OrderBy/ Then By/ Descending
            var orderData = products.OrderBy(g => g.CategoryId).ThenByDescending(g => g.Price).ToList();
            var orderBy = products.OrderBy(g => g.CategoryId).Select(h => h.CategoryId).ToList();
            var orderDataDesc = products.OrderByDescending(g => g.Price).Select(f => f.Price).ToList();

            // GroupBy
            var grupla = products.GroupBy(x => x.CategoryId).
                Select(g => new
                {
                    CategoryId = g.Key,
                    Amount = g.Count(),
                    AvgPrice = g.Average(f => f.Price)
                }).ToList();
        }
        #endregion
        public static void OparationDers8()
        {
            var categorys = new List<Category>
            {
                new(1,"Klawatura"), new(2,"Laptop"), new(3,"Ekran.")
            };

            var products = new List<Product>
            {
                new(1,"Xiomi",300m,50,2),
                new(2,"Dell",700m,50,2),
                new(3,"Lenova",500m,50,2),
                new(4,"Casper",400m,50,2),
                new(5,"Toshiba",400m,50,2),
                new(6,"Microsoft",100m,50,1),
                new(7,"Dell",300m,50,3),
            };

            var orders = new List<Order>
            {
                new(101, "Muhammet", new(){new (2,5,700m),new (6,5,100m)}),
                new(101, "Guwanç", new(){new (2,5,700m),new (6,5,100m)}),
                new(101, "Jeren", new(){new (1,5,33m),new (6,5,100m)})
            };

            // Ders 8
            // Joinler Birleşdirmek. 
            // Barded dine özümüze gerek boaln parametreler getiryars. Aslynda Dogrysy şul. Performans Tarapdan hem has gowy.    p.Name, Category = c.Name, p.Price
            var urunKategory = products
                .Join(categorys,
                p => p.CategoryId,
                c => c.Id, (p, c) =>
                new { p.Name, Category = c.Name, p.Price }).ToList();

            // bul görnüşü kam ulanmaz. Sebabi Efor we Kop CPU iyip bilyar. Sonun üçün Hokmany Suratda  Dine Gerek bolan Parametreleri almagymyz Möhüm. Mysal üçün yokarky mysal.
            var urunKategoryButunleyi = products
              .Join(categorys,
              p => p.CategoryId,
              c => c.Id, (p, c) =>
              new { p, Category = c }).ToList();

            // varlık soruları. Yagny Barmy yok my ? Distinct, Any, All, Contains
            var checkCategory = products.Select(x => x.CategoryId).Distinct().ToList();
            // Bar my yok my ? Munda Hokman Any
            bool isHaveInStock = products.Any(f => f.Stock == 0);
            // Hemmesi Stokda my All Ulanyars.
            bool isAllInStock = products.All(f => f.Stock > 0);

            // Yeke Data Getirmek. Yagny Tablissalar içerisinde  Yekeje Data Almak islesek, bu yagdayda , First/ FirstOrDefault, Signle / SingleOrDefault. 
            var firstData= products.First(); // Bu şertde  Tablissada Hökmany Suratda  in az 1 data bolmasy gerek. Eger data yok bolsa Bize Error berer. 
            var firstData2= products.First(d=>d.CategoryId==2);

            var firstDefault=products.FirstOrDefault(d=>d.CategoryId==2); // Munda hiçhili data bolmasada bolyar. Eger Tabissada data yok bolsa bize return null görkezer.
            var firstDefault2 = products.FirstOrDefault();

            // Single 
            var single= products.Single(); // Senin Tablissana Dine 1 data bolmaly. Eger 1 den az we 1 den köp bolsa bize Error  Berer.
            var single2=products.Single(x=>x.Id== 3);

            var singleDef= products.SingleOrDefault(x=>x.Id== 3); // Barde bolsa hem eger 1 den az bolsa bize null berer. 1 den köp bolsa Eroro berek. 
            var singleDef2= products.SingleOrDefault(); // Barde bolsa hem eger 1 den az bolsa bize null berer. 1 den köp bolsa Eroro berek. 

            // Sahypalama. Take, Skip,
            int sahypa = 2, sahypaUlulygy = 2;

            var ikinjiSahyypa=products
                .OrderByDescending(f=>f.Id)
                .Skip((sahypa-1)*sahypaUlulygy)
                .Take(sahypaUlulygy);

            // Hasaplamalarada ulanylyar. Count, Sum, Min/Max, AVG, 
            var productCount=products.Count();
            var totalStock=products.Sum(f=>f.Stock);
            var totalStockPrice=products.Sum(f=>f.Stock * f.Price);
            var expensivePro = products.MaxBy(k => k.Price);
            var expensiveProMax = products.Max(k => k.Price);

            var cheapest = products.MinBy(f => f.Price);
            var cheapestMin = products.MinBy(f => f.Price);

            var avgPrice= products.Average(f=>f.Price);
            

        }
    }
}
