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
        // Bu class-da biz C# dilindäki LINQ mümkinçiliklerini görkezýäris.
        // LINQ näme? -> "Dil bilen integrirlenen sorag" diýmegi, ýagny biz C# içinde
        // kolleksiýalara (List, Array, IQueryable, we ş.m.) SQL-çe sorag ýazyp bilýäris.
        //
        // Aşakdaky esasy operatorlar ulanylar:
        // - Where          : Filtrlemek (şerti geçen elementleri almak)
        // - Select         : Proýeksiýa / Map etmek (islenýän shape-e geçirmek)
        // - OrderBy        : Tertiplemek (artan)
        // - ThenBy         : Ikinji derejeli tertiplemek
        // - OrderByDescending : Azalan tertiplemek
        // - GroupBy        : Toparlaşdyrmak (bir açar boýunça)
        // - Join           : Iki sanawy birleşdirmek (SQL INNER JOIN ýaly)
        // - Distinct       : Tekrarlary aýyrmak
        // - Any / All      : Barla ("Biri barmy?", "Hemmesi şeýlemi?")
        // - First / FirstOrDefault : Ilkinji elementi almak
        // - Single / SingleOrDefault : Diňe 1 sany element bolanda almak
        // - Count / Sum / Average / Min / Max : Sanamak, jemlemek, statistikalar
        // - SelectMany     : Içindäki listlerden "tek sanaw" döretmek (flatten)
        //
        // Bu dünýäde professional programmistiň iň köp ulanýan dürli soraglary şu ýerde bar.


        // Example Method
        // record Keyword-ynyň manysy:
        // "record" C#-da ýagny "immutable data taşıyýan tip" görnüşidir.
        // Biz diňe maglumat saklaýarys, içindäki property-leri init etmek üçin döredilýär.
        // Meselem: new Category(1,"Laptop") diýýäris we ol bize obýekt berýär.
        public record Category(int Id, string Name);
        public record Product(int Id, string Name, decimal Price, int Stock, int CategoryId);

        public record OrderProsec(int ProductId, int Quantity, decimal unitPrice);

        public record Order(int Id, string Customer, List<OrderProsec> OrderProsecs);

        #region ders 7
        public static void Operations()
        {
            // categorys listi:
            // Bu ýerde biz täze List<Category> döredýäris.
            // new List<Category> { ... } => kolleksiýanyň içinde başlangyç elementleri berip bolýar.
            // new(1,"Klawatura") ýazmak: bu C# 9+ şugary, record tipini Id=1, Name="Klawatura" diýip berýär.
            var categorys = new List<Category>
            {
                new(1,"Klawatura"), new(2,"Laptop"), new(3,"Ekran.")
            };

            // products listi:
            // Product record-ynyň gurluşy: Product(int Id, string Name, decimal Price, int Stock, int CategoryId)
            // Biz her bir harydyň:
            //  - Id
            //  - Ady (Name)
            //  - Bahasy (Price)
            //  - Skladdaky sany (Stock)
            //  - Hangi kategoriýa degişlidigini (CategoryId)
            // saklaýarys.
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

            // orders listi:
            // Order record-ynda müşderi (Customer) we onuň alan zatlarynyň sanawy bar (OrderProsecs).
            // OrderProsec: ProductId, Quantity, unitPrice.
            // Diýmek, bir sargyt birden köp haryt saklap bilýär.
            var orders = new List<Order>
            {
                new(101, "Muhammet", new(){new (2,5,700m),new (6,5,100m)}),
                new(101, "Guwanç", new(){new (2,5,700m),new (6,5,100m)}),
                new(101, "Jeren", new(){new (1,5,33m),new (6,5,100m)})
            };

            // ********************
            // WHERE + COUNT()
            // ********************
            // .Where(predicate):
            // predicate => her element üçin true / false gaýtaran lambda.
            // Mysal: x => x.Stock > 0  => Stock 0-dan uly bolanlary saýla.
            //
            // .Count():
            // Netijede näçe element bardygyny sanap berýär.
            //
            // stoklaryBolan: stoky 0-dan uly bolan harytlar sany.
            var stoklaryBolan = products.Where(x => x.Stock > 0).Count();

            // controlData:
            // Bu ýerde iki şert ulanýarys:
            // f.CategoryId == 2  WE  f.Price >= 350m
            // Ýagny CategoryId=2 bolan (Laptop kategoriýasy ýaly) we bahasy azyndan 350m bolan käbir laptoplar näçe sany?
            var controlData = products.Where(f => f.CategoryId == 2 && f.Price >= 350m).Count();

            // ********************
            // WHERE + ToList()
            // ********************
            // .ToList() -> netije IQueryable däl, eýsem List<Product> şekline öwrülýär.
            // Filtrlenen maglumatlary soň UI-de görkezmek, foreach-de aýlamak üçin amatly.
            var controlStock = products.Where(x => x.Stock > 0).ToList();

            // filterData:
            // Bu hem ýokarky ýaly filtri bilen sanaw görnüşinde bize gaýtarylýar.
            var filterData = products.Where(f => f.CategoryId == 2 && f.Price >= 350m).ToList();

            // ********************
            // SELECT
            // ********************
            // .Select() => Proýeksiýa. Ýagny biz Product obýektiniň ähli property-lerini almak hökman däl.
            // Biz diňe gerek bolanlaryny saýlap bilýäris, meselem Name, Price, IsStock.
            // Täze anonim tip döredýäris: new { d.Name, d.Price, IsStock = ... }
            // TÄZE property adyny özümiz ýazyp bilýäris: IsStock =
            var productSummery = products.Select(d => new
            {
                d.Name,
                d.Price,
                IsStock = d.Stock > 0 ? "Bar" : "Yok" // ternary operator: şert ? dogryda : ýalňyşda
            }).ToList();

            // justname:
            // Diňe harytlaryň adlaryny (Name) alýarys. Netije List<string> bolýar.
            var justname = products.Select(j => j.Name).ToList();

            // ********************
            // ORDERBY / THENBY / DESCENDING
            // ********************
            // OrderBy(g => g.CategoryId):
            // Ilki CategoryId boýunça artýan görnüşde tertiple.
            // Soň .ThenByDescending(g => g.Price):
            // Eger CategoryId deň bolsa, şol bir kategoriýanyň içinde bahasy boýunça peselýän tertiple.
            var orderData = products
                .OrderBy(g => g.CategoryId)
                .ThenByDescending(g => g.Price)
                .ToList();

            // orderBy:
            // Bu diňe tertipleýär, soňra diňe CategoryId-lerini alýar.
            // Netije: şol Id-leriň sanawy.
            var orderBy = products
                .OrderBy(g => g.CategoryId)
                .Select(h => h.CategoryId)
                .ToList();

            // orderDataDesc:
            // Bu ýerde diňe Price boýunça azalan (ulydan kiçi) tertipleýäris.
            // Soň diňe Price sanawyny alýarys.
            var orderDataDesc = products
                .OrderByDescending(g => g.Price)
                .Select(f => f.Price)
                .ToList();

            // ********************
            // GROUPBY
            // ********************
            // GroupBy(x => x.CategoryId):
            // Bu ähli product-lary CategoryId boýunça toparlaýar.
            // Netijede her toparda şol kategoriýa degişli harytlar bolýar.
            //
            // Soňra .Select(g => new { ... }):
            // g.Key => GroupBy edilen açar (CategoryId)
            // g.Count() => şol toparyň içinde näçe element bar
            // g.Average(f => f.Price) => şol toparyň ortaça bahasy
            var grupla = products
                .GroupBy(x => x.CategoryId)
                .Select(g => new
                {
                    CategoryId = g.Key,
                    Amount = g.Count(),
                    AvgPrice = g.Average(f => f.Price)
                })
                .ToList();
        }
        #endregion

        public static void OparationDers8()
        {
            // Öňki ýaly başlangyç demo datalary gaýtadan döretdik
            // Sebäbi bu method özbaşdak hem işlär ýaly bolmaly.
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

            // ************************************
            // JOIN
            // ************************************
            // .Join(innerList, outerKeySelector, innerKeySelector, resultSelector)
            //
            // products.Join(categorys,
            //    p => p.CategoryId,   // Daşarky sanawdan (products) açar
            //    c => c.Id,           // Içerki sanawdan (categorys) açar
            //    (p,c) => new {...})  // Netijäni nädip döretmeli?
            //
            // Bu SQL-deki INNER JOIN ýaly işleýär.
            // Ýagny harydyň CategoryId bilen kategoriýanyň Id-si deň bolan taýlary birleşdirýär.
            //
            // BIZ NAHILI MAGLUMATY ALÝARIS?
            // - diňe gerek bolan property-leri almaly: p.Name, c.Name, p.Price
            // Bu praktiki taýdan möhüm, sebäbi ähli tablisany serialize edip daşardan taşamak (API-de, mobile-de)
            // performansy öldürýär. Diňe gerek bolanlaryny almak has dogry.
            var urunKategory = products
                .Join(
                    categorys,
                    p => p.CategoryId, // product-yň haýsy kategoriýa degişliidigini görkezýän açar
                    c => c.Id,         // kategoriýanyň Id-si
                    (p, c) =>          // Bu lambda iki tarapdan gelen maglumatlary birleşdirýär
                    new
                    {
                        p.Name,             // harydyň ady
                        Category = c.Name,  // kategoriýanyň ady
                        p.Price             // harydyň bahasy
                    }
                )
                .ToList();

            // urunKategoryButunleyi:
            // Bu ýerde biz ähli p (Product) we ähli c (Category) obýektlerini saklaýarys.
            // Bu köp ýagdaýda GEREK DÄL, sebäbi artykmaç maglumat getirýär.
            // Ulanylanda performance ölýär (aýratynlykda real DB soraglarynda).
            // Şonuň üçin ↑ ýokardaky ýaly diňe gerek bolan property-ler bilen gitmek has gowudyr.
            var urunKategoryButunleyi = products
              .Join(
                  categorys,
                  p => p.CategoryId,
                  c => c.Id,
                  (p, c) =>
                  new
                  {
                      p,
                      Category = c
                  }
              )
              .ToList();

            // ************************************
            // DISTINCT / ANY / ALL / CONTAINS (varlyk soraglary)
            // ************************************
            // Distinct():
            // Gaýtalanýan gymmatlary aýyrýar. Mysal üçin CategoryId [2,2,2,1,3...] => [2,1,3]
            var checkCategory = products
                .Select(x => x.CategoryId)
                .Distinct()
                .ToList();

            // Any():
            // "Sanawyň içinde beýle element bar my?" soragy.
            // isHaveInStock => stoky 0 bolan haryt BARMY?
            // Eger bir element bolsa hem true gaýdar.
            bool isHaveInStock = products.Any(f => f.Stock == 0);

            // All():
            // "Hemmesi şeýlemi?" soragy.
            // isAllInStock => HEMME haryt Stock > 0 my?
            // Eger biri-de false bolsa, netije false bolýar.
            bool isAllInStock = products.All(f => f.Stock > 0);

            // ************************************
            // FIRST / FIRSTORDEFAULT
            // ************************************
            // First():
            // List-de ilkinji gelen elementi berýär.
            // EGER LIST BOŞ bolsa -> Exception (hatap) atyp biler.
            var firstData = products.First(); // Diýmek: bu hatasız işlemäge diňe products içinde iň az 1 element bolmaly.

            // First(predicate):
            // Şert geçýän ilkinji elementi alýar.
            // Eger hiç kim geçmese -> Exception.
            var firstData2 = products.First(d => d.CategoryId == 2);

            // FirstOrDefault():
            // Şert tapylsa -> şol elementi berýär.
            // Tapylmasa -> default gymmatyny berýär.
            // Reference tipler üçin default => null.
            // Şonuň üçin bu has howpsuz, sebäbi boş sanawda hem hatap atmadyk bolýar.
            var firstDefault = products.FirstOrDefault(d => d.CategoryId == 2);
            var firstDefault2 = products.FirstOrDefault();

            // ************************************
            // SINGLE / SINGLEORDEFAULT
            // ************************************
            // Single():
            // Sanawda DINE BIR element bolmaly.
            // - Eger 0 element bolsa -> Exception.
            // - Eger 2+ element bolsa -> Exception.
            //
            // Bu nähili ýerde ulanylýar?
            // Mysal üçin Id bilen gözleýän bolsaň we şol Id diňe 1 gezek bolmaly diýen biznes düzgün bar bolsa.
            //
            // !!! DIKKAT:
            // products.Single() nämä çenli howply:
            // products bizde 1-den köp element saklaýar.
            // Bu hatap atar. Şeýlelikde bu setir realda runtime-da Exception berer.
            var single = products.Single();

            // Single(predicate):
            // Şert boýunça tapylýan element DINE 1 sany bolmaly.
            // Eger köp bolsa ýa-da bolmasa Exception.
            var single2 = products.Single(x => x.Id == 3);

            // SingleOrDefault(predicate):
            // Eger 0 element tapsa -> default (reference tip üçin null) gaýdarýar.
            // Eger DINE 1 tapsa -> şony berýär.
            // Eger 2+ tapsa -> Exception.
            var singleDef = products.SingleOrDefault(x => x.Id == 3);

            // Bu görnüş hem edil ýokardaky ýaly işläp dur, ýöne predicate ýok.
            // Ýagny sanawyň özi diňe 1 element bolsady, şony gaýtarmalydy.
            // Köp element bar bolsa -> Exception.
            var singleDef2 = products.SingleOrDefault();

            // ************************************
            // SAHYPALAMA (PAGING): Skip / Take
            // ************************************
            // Web API / UI-da umumy sanawyň hemmesini birden bermegiň ýerine,
            // sahypa-sahypa görkezmeli bolýarys.
            //
            // Mysal:
            // sahypa = 2, sahypaUlulygy = 2 =>
            // Bize 2-nji sahypanyň elementlerini getir.
            //
            // Formula:
            // Skip((sahypa-1)*sahypaUlulygy)
            // Take(sahypaUlulygy)
            //
            // Bu ýerde biz ilki tertipleýäris (OrderByDescending(f=>f.Id)),
            // soň şol tertip boýunça gerekli bölegi alýarys.
            int sahypa = 2, sahypaUlulygy = 2;

            var ikinjiSahyypa = products
                .OrderByDescending(f => f.Id)                // Ilki Id boýunça uludan kiçi tertiple
                .Skip((sahypa - 1) * sahypaUlulygy)            // Ilkinji sahypalary taşla
                .Take(sahypaUlulygy);                      // Soň galanlaryň ilkinji 2 sanyny al

            // ************************************
            // AGGREGATION / STATISTIKA FUNKSIÝALARY
            // ************************************
            // Count()          : Näçe element bar?
            // Sum()            : Jemi näçe?
            // Max(), MaxBy()   : Iň uly bahaly zat / şol zadyň özi
            // Min(), MinBy()   : Iň arzan bahaly zat / şol zadyň özi
            // Average()        : Ortaça bahasy näçe?
            //
            // Bu funksiýalar hasabat, dashboard, grafik taýýarlamak ýaly ýagdaýlarda köplenç ulanylýar.

            var productCount = products.Count(); // umumy haryt sany

            var totalStock = products.Sum(f => f.Stock); // umumy sklad sany (hemme harytlaryň stocklarynyň jemi)

            var totalStockPrice = products.Sum(f => f.Stock * f.Price);
            // Umumy potansial gymmat: her haryt üçin Stock * Price edip,
            // soň olaryň hemmesini jemleýäris.

            var expensivePro = products.MaxBy(k => k.Price);
            // MaxBy(selector):
            // Bahasy iň ýokary bolan Product obýektini gaýtaryp berýär.
            // Mysal üçin: iň gymmat laptop haýsy?

            var expensiveProMax = products.Max(k => k.Price);
            // Max(selector):
            // Diňe iň ýokary bahany berýär (san görnüşinde).
            // Mysal üçin: iň ýokary baha näçe?

            var cheapest = products.MinBy(f => f.Price);
            // MinBy(selector):
            // Bahasy iň arzan bolan Product obýektini berýär.

            var cheapestMin = products.MinBy(f => f.Price);
            // Bu ýerde hem edil birmeňzeş ýazylan eken, logika şol bir.

            var avgPrice = products.Average(f => f.Price);
            // Average(selector):
            // Harytlaryň ortaça bahasyny tapýar.
            // Statistika üçin peýdaly (mes: orta bazar bahasy näçe?)

        }
    }
}
