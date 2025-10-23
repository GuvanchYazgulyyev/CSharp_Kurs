using CSharp_Kurs.Kurslar.Ders2;

namespace CSharp_Kurs;

public class Program
{
    public static void Main(string[] args)
    {
        // Calculator.RunCalculator(args);
        //Ders5.Ders_5();

    }

    #region Ders1 
    public static void Main2(string[] args)
    {

        // Types
        // int , double, decimal, bool, string, char,
        int a = 2;
        double pi = 3.14159;
        decimal aylyk = 3851556.52m;// finans ssitemasynda
        bool test = false;
        char xx = 'a';
        string testData = "test Mysal";
        var ulke = "TKM";
        const double KDV = 1.0;
        Console.WriteLine($"Rsult: {a}, Pi Sany: {pi}, Aylyk: {aylyk.ToString()}");
        Console.WriteLine("Salam Dünya!");

        // Şertler We Mysallar.
        // Mysal Uni Baha Sistemasy. (IF)
        int bal = 85;
        if (bal >= 90)
            Console.WriteLine("AA");
        else if (bal >= 80)
            Console.WriteLine("BA");
        else if (bal >= 65)
            Console.WriteLine("BB");
        else
            Console.WriteLine("Galdy!");

        // Switch  
        int gun = 3;
        switch (gun)
        {
            case 1: Console.WriteLine("Monday"); break;
            case 2: Console.WriteLine("Tuesday"); break;
            case 3: Console.WriteLine("Wednesday"); break;
            default: Console.WriteLine("Unknown"); break;
        }

        // C# 8+ arrow Function
        int x = 0;
        string tip = x switch
        {
            < 0 => "Negatiw",
            0 => "Nol",
            > 0 => "Pozitif"
        };
        Console.WriteLine(tip);


        // Loop 
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"For Loop: {i}");
        }
        // Whili
        int j = 0;
        while (j < 5)
        {
            Console.WriteLine($"While Loop: {j}");
            j++;
        }

        string[] diller = { "C#,Java,Python,SQL" };
        foreach (var dil in diller)
            Console.WriteLine($"ForEach: {dil.ToString()}");

        // Methodlary çagyr. 
        Console.WriteLine(Dortgen(0));
        Yazgy();
        Yazgy("Muhammet");
        var kisiCagyr = new Kisi("Guwanç", 28);
        kisiCagyr.Tanat();
        Console.WriteLine(kisiCagyr);

    }
    // Methodlar. 
    public static int Dortgen(int n) => n * n;
    public static void Yazgy(string ad = "Guwanç")
    {
        Console.WriteLine(ad);
    }

    #endregion

}







//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
