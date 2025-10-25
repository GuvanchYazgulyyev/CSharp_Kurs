using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CSharp_Kurs.Kurslar.Delegates
{
    public class LinqC
    {
        public static void RunLinqQueryExample()
        {
            Console.WriteLine("--- 1. Query Syntax: Filtering Scores ---");
            int[] scores = [97, 92, 81, 60];

            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute using query
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");


            Console.WriteLine("--- 2. Query Syntax: Filtering Even Numbers ---");
            int[] numbers = [0, 1, 2, 3, 4, 5, 6];

            // Query creation: numQuery is an IEnumerable<int>
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;

            // Query execution
            foreach (int num in numQuery)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine("\n");

            Console.WriteLine("--- 3. Immediate Execution (Count, ToList, ToArray) ---");

            var evenNumQuery = from num in numbers
                               where (num % 2) == 0
                               select num;

            // Count() forces immediate execution
            int eventNumCount = evenNumQuery.Count();
            Console.WriteLine($"Even number count: {eventNumCount}");


            // ToList() forces immediate execution into a List<T>
            List<int> numQuery2 = (from num in numbers
                                   where (num % 2) == 0
                                   select num).ToList();

            // ToArray() forces immediate execution into an Array
            var numQuery3 = (from num in numbers
                             where (num % 2) == 0
                             select num).ToArray();

            List<int> numbers2 = [1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20];

            IEnumerable<int> queryFactorOfFour = from num2 in numbers2
                                                 where (num2 % 4) == 0
                                                 select num2;

            // Store the result in a new variable using ToList()
            var factorofFourList = queryFactorOfFour.ToList();

            // Read and write from the newly created list to demonstrate that it holds data.
            Console.WriteLine($"\nFactor of Four List (Immediate Execution):");
            Console.WriteLine($"The second number in the list is: { factorofFourList[1]}"); // Index 1 is the second element (8)
            
            // Modify the materialized list (the LINQ query is NOT re-run)
            factorofFourList[1] = 0; 
            Console.WriteLine($"After modification, the second element is: {factorofFourList[1]}");

            Console.WriteLine("\n--- 4. LINQ with Records (Method Syntax) ---");

            // LIST INITIALIZED USING PRIMARY CONSTRUCTOR SYNTAX
            List<Package> packages =
            [ 
                new Package("Coho Vineyard", 25.2),
                new Package("Lucerne Publishing", 18.7),
                new Package("Wingtip Toys", 6.0),
                new Package("Adventure Works", 33.8)
            ];

            // Method Syntax: Filter by weight and project to a new anonymous type
            string[] companies = packages.Select(pkg => pkg.Company).ToArray();
            foreach (string company in companies)
            {
                Console.WriteLine(company);
            }

            var heavyPackages=packages.Where(x=>x.Weight>20).Select(x =>new{Name=x.Company,x.Weight} ).ToList();

            foreach (var pkg in heavyPackages)
            {
                Console.WriteLine($"20 kg den agyr paketler- {pkg.Name} ({pkg.Weight} kg)");
            }
             Console.WriteLine("\n-------------------------------------------");

            Console.WriteLine("____Lets do it now with Dictionaries ");
            Console.WriteLine("--- Simple LINQ Query: Filter Dictionary by Value ---");
            // 1. Data Source: A Dictionary of student names (Key) and scores (Value).

            var studentScores = new Dictionary<string, int>{
                  { "Alice", 95 },
                { "Bob", 78 },
                { "Yusup", 92 },
                { "David", 88 },
                { "Eve", 65 }

            };

            Console.WriteLine($"Total Students: {studentScores.Count}");
            // 2. Query Definition (Deferred Execution):
            // We treat the dictionary as a collection of KeyValuePair<string, int> objects.
            var honorRollQuery =
            from student in studentScores
            where student.Value >= 90  // Filter the elements based on the Value (score)
            orderby student.Value descending
            select new { student.Key, student.Value };


            Console.WriteLine("\nStudents on the Honor Role (Score >=90:)");
            foreach(var record in honorRollQuery)
            {
                Console.WriteLine($" In goreldeli okuwcy \t {record.Key}:{record.Value}");


            } Console.WriteLine("\n-------------------------------------------");

            Dictionary<string, int> honorRollLookup = studentScores
            .Where(s => s.Value >= 90).ToDictionary(
                s => s.Key,
                s => s.Value);

            if (honorRollLookup.ContainsKey("Alice"))
            {
                Console.WriteLine($"Alice made the honor roll with a score of {honorRollLookup["Alice"]}");
            }


            Console.WriteLine("____queryMajorCities and queryMajorCities2 are query variables:");

            

            City[] cities = [
new City("Tokyo",37_833_000),
new City("Delhi",30_290_000),
new City("Shanghai",27_110_000),
new City("Ashgabat",600_000_000)

            ];
            IEnumerable<City> queryMajorCities =
            from city in cities
            where city.Population > 30_000_000
            select city;

            //exacute the query and produce the results\
            foreach (City city in queryMajorCities)
            {
                Console.WriteLine(city);
            }

            Console.WriteLine("yokarky kod gaty kop hem gin gelin kiceldelin");

            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 30_000_000);
            foreach (City city in queryMajorCities2)
            {
                Console.WriteLine(city);
            }
            IEnumerable<City> queryMajorCities3= cities.Where(c => c.Population > 30_000_000);
Console.WriteLine(string.Join(Environment.NewLine, queryMajorCities3));
            {
                
            }

        }
    }


    public record Package(string Company, double Weight);
    public record City(string Name, long Population);
    public record Country(String Name,double Area, long Population,List<City> Cities);
}
