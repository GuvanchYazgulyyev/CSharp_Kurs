using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace CSharp_Kurs.Kurslar.Delegates
{
    public class Sapak7
    {

        //Example method 
        public record Category(int Id,string Name);

        public record Product(int Id,string Name, decimal Price,int Stock,int CategoryId);

        public record OrderProsec(int ProductId,  int Quantity,decimal unitPrice );


        public record Order(int Id,string Customer,List<OrderProsec> OrderProsecss);



        public static void Operations()
        {
            var categorys = new List<Category>
            {
                new(1,"Klawitura"),new (2,"Laptop"),new(3,"Ekran")
            };

            var products = new List<Product>
            {
                new(1,"Xiomi",300m,50,2),
                new(2,"Dell",700m,50,2),
                new(3,"lenova",500m,50,2),
                new(4,"Casper",400m,50,2),
                new(5,"Toshiba",400m,50,2)


            };

            var orders = new List<Order>
            {
                new(101,"Muhammet",new(){new (2,5,700m),new (6,5,100m)}),
                new(101,"Guwanc",new(){new (2,5,700m),new (6,5,100m)}),
                new(101,"Jeren",new(){new(1,5,33m),new(6,5,100m)})


            };
            //fileterleme 
            var stoklaryBolan = products.Where(x => x.Stock > 0).Count();
            var controlData = products.Where(f => f.CategoryId == 2 && f.Price >= 350m).Count();

            //filerleme where we list gornushidnde ber

            var controlStock = products.Where(x => x.Stock > 0).ToList();
            var filterData = products.Where(f => f.CategoryId == 2 && f.Price >= 350m).ToList();


            //Select (ananim type )

            var productSummary = products.Select(d => new { d.Name, d.Price, IsStock = d.Stock > 0 ? "Bar" : "yok" }).ToList();
            var justName = products.Select(j => j.Name).ToList();

            //order by decending then by descending

            var orderData = products.OrderBy(g => g.CategoryId).ThenByDescending(g => g.Price).ToList();
            var orderBy = products.OrderBy(g => g.CategoryId).Select(h => h.CategoryId).ToList();

            var orderDataDesc = products
          .OrderByDescending(g => g.Price).Select(f => f.Price).ToList();

            //Groupby
            var grupla = products.GroupBy(x => x.CategoryId).Select(g => new
            {
                CategoryId = g.Key,
                Amount = g.Count(),
                AvgPrice = g.Average(f => f.Price)
            }).ToList();
            
            


            



        



        }





    }
    
}