namespace CSharp_Kurs.Kurslar.Ders2
{
    public class Ders8
    {
        // Linq dowam etyar. List ToDictionary.

        public record Film(int id, string Name, int Year, string Genre, double Rating);
        public static List<Film> filimler { get; } = new List<Film>
        {
        new Film(1,"Dune",2011,"Action",8.0),
        new Film(2,"Black Widow", 2023, "Action", 6.7),
        new Film(3,"The Kissing Booth 3", 2021, "Romance", 5.3),
        new Film(4,"Love Hard", 2021, "Romance", 6.3),
        new Film(5,"Wonder Woman 1984", 2025, "Action", 5.4),
        new Film(6,"Tenet", 2020, "Action", 7.8),
        new Film(7,"A Quiet Place Part II", 2021, "Thriller", 7.3),

        };

        public record CategoryLinq(int Id, string Name);
        public record ProductLinq(int Id, string Name, decimal Price, int Stock, int CategoryId);


        public static void OperationData()
        {
            var listBer = filimler.Where(f => f.Year >= 2022).ToList(); // List bere
            var dictionaryList = filimler.ToDictionary(k => k.id);// Bardeki data Uniq bolmaly.  ID

            // Eşdeger
            var q1 = filimler.Where(f => f.Year >= 2022).Select(k => k.Name).ToList();


            var aq = (from u in filimler
                      where u.Year >= 2022
                      select u).ToList();





            var categorys = new List<CategoryLinq>
            {
                new(1,"Klawatura"), new(2,"Laptop"), new(3,"Ekran.")
            };

            var products = new List<ProductLinq>
            {
                new(1,"Xiomi",300m,50,2),
                new(2,"Dell",700m,50,2),
                new(3,"Lenova",500m,50,2),
                new(4,"Casper",400m,50,2),
                new(5,"Toshiba",400m,50,2),
                new(6,"Microsoft",100m,50,1),
                new(7,"Dell",300m,50,3),
            };


            // İleri Düzey LINQ EF Core bilen LINQ
            // Navidation bilen Linq
       
                
        }

    

    }
}
