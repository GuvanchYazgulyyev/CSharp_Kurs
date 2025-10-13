namespace CSharp_Kurs.Kurslar.Ders2
{
    public class Ders4
    {
        // OOP - Object Oriented Programming (2)
        public static class SozlemKomekcileri
        {
            public static string IcMethod(string input)
                => string.Join("-", input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToLowerInvariant();
        }
        // Metotlar: Overload, Optional, Expression-bodied, Local Function işlenmeli.

    }

    // abstract/virtual/override/sealed

    public abstract class KargoHasaplama
    {
        public abstract string Ady { get; }
        public virtual decimal Baha(decimal desi, decimal yolUzunlyk)
            => Math.Round(desi * 2m + yolUzunlyk * 0.5m, 2);
    }

    public class StandartKargo : KargoHasaplama
    {
        public override string Ady => "Standart Kargo";
    }

    public class TizKargo : KargoHasaplama
    {
        public override string Ady => "Tiz Kargo";

        public sealed override decimal Baha(decimal desi, decimal yolUzunlyk) //
        {
            return Math.Round(base.Baha(desi, yolUzunlyk) * 1.6m, 2); // sealed indi muny override edilemez.
        }
        public static string KatgoJogap(KargoHasaplama k) => k switch
        {
            TizKargo => "Tiz Kargo saýlandy",
            StandartKargo => "Standart Kargo saýlandy",
            _ => "Näbelli Kargo"
        };
    }


    // abstract Tüketilecek in köp synyplar üçin ulanylýar. Önki datalary aşaky (methodda) datalar üytgedip biler. 
    // virtual/ ovverride: Herkedini aşakdaky synyplarda üytgedip bilýäris.
    // sealed ovverride:  Belli bir yerden sonra ovverride edilmesin diyip ulanylýar. Yagny ovverride edilmeyar. 

    // Interface: 

    public interface INalokPolitikasy
    {
        decimal Nalok { get; }
        // C# 8+ default interface methodlary
        decimal Hasapla(decimal tutar)
        {
            return Math.Round(tutar * (1 + Nalok), 2, MidpointRounding.AwayFromZero);
        }
    }
    public class Nalok10 : INalokPolitikasy
    {
        public decimal Nalok => 0.10m;
    }

    public class Nalok20 : INalokPolitikasy
    {
        public decimal Nalok => 0.20m;
    }

    public interface IJsonYAzdyr { void Yaz(object o); }

    public class ConselJson : IJsonYAzdyr
    {
        public void Yaz(object o)
        {
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(o));
        }
    }


}
