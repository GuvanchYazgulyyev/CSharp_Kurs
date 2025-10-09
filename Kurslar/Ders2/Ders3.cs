namespace CSharp_Kurs.Kurslar.Ders2
{
    public class Ders3
    {
        //  public
        // private
        // protected: synyp we aşaky synyplarda ulanylyar. 
        // internal Şol bir yerdee (Asembly) içinde

    }
    public class Mysal
    {
        private int _gizlinSan = 55; // dine Bu synypda görüner.
        internal string IcNot = "Salam Guwanç. "; // menzeş assembly içinde işler. 
        public void yaz() => Console.WriteLine(_gizlinSan);
    }

    //Filed Property

    public class Mysal2
    {
        private string _ad = "Bilinmeyan";
        public int Yas { get; private set; } = 0;// daşarda Setlenmesin diyip men privite goşdym. set bölegine 

        // Full Property
        public string Ad
        {
            get => _ad;
            set => _ad = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Ad yeri doly girilmeli")
                : value.Trim();
        }

        public string Kisilik => $"{Ad} ({Yas})";

        public void Kisi(string ad, int yas)
        {
            Ad = ad;
            Yas = Math.Max(0, yas);
        }

        // init we required 
        public class kisiReq
        {
            public required string UserName { get; init; } // Mejbury Gir
            public string Email { get; init; }
        }


        public static void TestEt()
        {
            var getData = new kisiReq { UserName = "Webigem", Email = "info@webigem.com.tr" };
            Console.WriteLine(getData);
        }
    }


    // C# 12 Primary Ctor.

    // Klasik + chating
    public class DikDortgen
    {
        public double Ginislik { get; }
        public double Yokarky_Ginislik { get; }
        public double Meydan => Ginislik * Yokarky_Ginislik;

        public DikDortgen(double gin, double yokary)
        {
            if (gin <= 0 || yokary <= 0)
                throw new ArgumentOutOfRangeException();
            Ginislik = gin;
            Yokarky_Ginislik = yokary;
          
        }
        public DikDortgen(double gyrasy): this(gyrasy, gyrasy)
        {

        }
    }
    // C# 12 Primary Ctor
    public class Daire(double yartyBolegi)
    {
        public double Yarsy { get; } = yartyBolegi > 0 ? yartyBolegi: throw new ArgumentOutOfRangeException();
        public double Meydany => Math.PI * Yarsy * Yarsy;
    }

    // const we readonly
    public class Sazlama
    {
        public const double Taks = 0.20; // Bu üytgemze
        public readonly DateTime AcylysWagty = DateTime.UtcNow;
    }


}
