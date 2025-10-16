using System.Collections;
using System.Linq;

namespace CSharp_Kurs.Kurslar.Ders2
{
    public class Ders5
    {
        //Array Methods 
        //List<T>: // Dinamik  Dizi, Muny Durmuşda in köp ulanylyar.
        // Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();// Bu gysgaça gözlemek we goşmak üçin ulanylýar.
        //HashSet<int> hashSet = new HashSet<int>();// Unikal sanlary saklamak üçin ulanylýar.
        // Guid.NewGuid(); // Unikal ID döretmek üçin ulanylýar.
        //Queue<string> queue = new Queue<string>();// Birinji giren birinji çykýar (FIFO).
        //Stack<string> stack = new Stack<string>();// Birinji giren soňky çykýar (LIFO).
        //SortedList<int, string> sortedList = new SortedList<int, string>();// Açar we bahasy boýunça tertipleýär.

        // List<T> Methods(goşmak, aayyrmak, pozmak, tertiplemek)
        public static void Ders_5()
        {
            var sanlar = new List<int> { 7, 3, 9 };
            sanlar.Add(5); // Goşmak barde in sona goşar.
            sanlar.Insert(1, 55); // Goşmak barde in islenilen ýere goşar.
            sanlar.Remove(3); // Aýyrmak barde in islenilen sany aýyrar.
            bool kontrol = sanlar.Contains(9); // Barde in islenilen sany bar ýa ýokdygyny barlar. // true false

            // Şertli pozmak.
            sanlar.RemoveAll(f => f % 2 == 1); // Jüp sanlary pozar.
            sanlar.Sort(); // Tertiplemek kiçi sanlardan uly sanlara.
            var cubutler = sanlar.FindAll(x => x % 2 == 0); // Jüp sanlary tapar we täze list döreder.

            var adlar = new List<string> { "Guwanç", "Maksat", "Muhammet", "Jeren", "Hurma" };
            adlar.Sort(); // Alfawit tertibinde tertiplemek.
            adlar.Sort((a, b) => b.Length - a.Length); // Uzynlygyna görä ters tertiplemek.
            Console.WriteLine(string.Join(", ", adlar)); // Listi stringe öwürmek we çap etmek.
        }

        public static void Dictionary_HashSet()
        {
            // Dictionary<TKey, TValue> Mysaly
            var dictionaryData = new Dictionary<string, string>
            {
                ["TM"] = "Türkmenistan",
                ["TR"] = "Türkiýe",
                ["AZ"] = "Azerbaýjan"
            };
            dictionaryData["RU"] = "Russiýa"; // Goşmak
            dictionaryData.Remove("RU"); // Aýyrmak
            if (dictionaryData.TryGetValue("TM", out var ad))
                Console.WriteLine($"TM: {ad}"); // Gözlemek

            // HashSet<T> Mysaly
            var setA = new HashSet<int> { 1, 2, 3, 4 };
            var setB = new HashSet<int> { 3, 4, 5, 6 };
            setA.IntersectWith(setB); // setA we setB arasyndaky umumy elementleri saklar.
            setB.ExceptWith(new[] { 6 });

            Enum_IEnumerator();

        }

        // Enumarable ve IEnumerator Mysaly
        public static void Enum_IEnumerator()
        {
            static IEnumerable<int> Aralyk(int start, int end)
            {
                for (int i = start; i <= end; i++)
                    yield return i; // Her bir elementi yzyna gaýtarýar.
            }
            foreach (var san in Aralyk(1, 15))
                Console.WriteLine(san);

            Delege_Maşgala();
        }

        // Delege Maşgalasy. Action, Func, Predicate
        public static void Delege_Maşgala()
        {

            Action<string> print = mesaj => Console.WriteLine(mesaj);
            Func<int, int, int> topla = (a, b) => a + b;
            Predicate<int> yekemi = san => san % 2 == 1;
            print($"Toplam: {topla(2, 3)}"); // Toplam: 5
            Console.WriteLine(yekemi(5)); // True


        }
    }
}
