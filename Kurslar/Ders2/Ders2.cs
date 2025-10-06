using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Kurs.Kurslar.Ders2
{
    public class Ders2
    {
        // Ders 2 
        // Listler
        public static void Ders2_Data()
        {
            int[] sanlar = { 1, 2, 3, 4, 5, 6, 7, };

            // Lİst
            var adlar = new List<string> { "Guwanç", "Maksat", "Muhammet", "Jeren", "Hurma" };
            adlar.Add("Gülşat");
            Console.WriteLine(adlar.Count);
            Console.WriteLine(adlar[3]);
            foreach (var ad in adlar)
                Console.WriteLine(ad);


            // error Görnüşleri.
            try
            {
                Console.WriteLine("Bölünen: ");
                int a = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Bölen: ");
                int b = int.Parse(Console.ReadLine()!);

                int result = a / b;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex) //0 a Bölünmeyan yalnyşlyk.
            {
                Console.WriteLine($"0 a Bölünmez Yalnyşlygy! {ex.Message}");
            }
            catch (FormatException ex) // Format Talnyyşlyk.
            {
                Console.WriteLine("San girin Girilen Forman Başga: " + ex);
            }
            catch (Exception ex) // Global Yalnyşlyk.
            {
                Console.WriteLine(ex.Message);
                throw (ex);
            }
            finally // Name Bolsa bolsun Dowam Et.
            {
                Console.WriteLine("Name Bolsa bolsun men işlejek:) ");
                Ders2_Data();
            }

        }

        // Bal Hasaplama
        public static void BalHasapla()
        {
            var ballar = new List<int>();
            while (true)
            {
                Console.WriteLine("Bal Yazyn: (Çykmak isleseniz Boşlyk Goyyn!): ");
                var girdi=Console.ReadLine();
                if(string.IsNullOrWhiteSpace(girdi)) break;
                if (int.TryParse(girdi, out int x) && x is >= 0 and <= 100)
                    ballar.Add(x);
                else
                    Console.WriteLine("0-100 arasynda san yazyn.");

            }
            if (ballar.Count == 0)
                Console.WriteLine("Ballar Girilmedi!");
            else
            {
                double ort = 0;
                foreach (var f in ballar) ort += f;
                {
                    ort /= ballar.Count;
                    Console.WriteLine($"Bal Sany: {ballar.Count}, Ortaça Baha: {ort:F2}");
                }
            }
        }
    }
}
