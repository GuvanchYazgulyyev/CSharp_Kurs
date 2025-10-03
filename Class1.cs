using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Kurs
{
    public class Kisi
    {
        public string Ad { get; set; }
        public int Yas { get; set; }

        public Kisi(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void Tanat()
        {
            Console.WriteLine($"Men: {Ad}, {Yas}");
        }
        public override string ToString() => $"{Ad}({Yas})";
    }
}
