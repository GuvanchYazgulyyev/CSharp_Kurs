using System.Collections.Generic;
using System.Linq;

// Define the data structure for a Film using a C# record.

public record Film(string Name,int Year,string Genre ,double Rating);
// --- Separate Class for LINQ Logic and Data ---
public static class FilmProcessor
{
    // Static property to hold the list of films (the data)
    public static List<Film> AllFilms { get; } = new List<Film>
 {
     new Film("Dune",2011,"Action",8.0),
      new Film("Black Widow", 2021, "Action", 6.7),
        new Film("The Kissing Booth 3", 2021, "Romance", 5.3),
        new Film("Love Hard", 2021, "Romance", 6.3),
        new Film("Wonder Woman 1984", 2020, "Action", 5.4),
        new Film("Tenet", 2020, "Action", 7.8),
        new Film("A Quiet Place Part II", 2021, "Thriller", 7.3),
        new Film("No Time to Die", 2021, "Action", 7.3),
        new Film("The Old Guard", 2020, "Action", 6.6),
        new Film("Happiest Season", 2020, "Romance", 6.9),
        new Film("Mank", 2020, "Drama", 7.0),
        new Film("The Father", 2020, "Drama", 8.2),
        new Film("Another Round", 2020, "Drama", 7.7),
        new Film("Promising Young Woman", 2020, "Thriller", 7.5),
        new Film("Zack Snyder's Justice League", 2021, "Action", 8.0)
 };

    /// <summary>
    /// Filters films by year (2020+), groups them by genre, and returns the top two
    /// highest-rated films per genre, sorted by name if ratings are equal.
    /// </summary>
    /// <param name="films">The complete list of films.</param>
    /// <returns>An IEnumerable of formatted strings (Genre - Name (Rating)).</returns>
    public static IEnumerable<string> GetTopFilmsByGenre(List<Film> films)
    {
        var topFilmsByGenre = films
           .Where(f => f.Year >= 2020)
           .GroupBy(f => f.Genre)
           .SelectMany(group => group
               .OrderByDescending(f => f.Rating)
               .ThenByDescending(f => f.Name)
               .Take(3)
               .Select(f => $"{f.Genre}-{f.Name}-({f.Rating:F1})").OrderBy(s => s));
        return topFilmsByGenre;
    }

    /// <summary>
    /// Runs the query on the internal AllFilms list and outputs the result to the console.
    /// This simplifies execution in Program.cs.
    /// </summary>
    public static void RunAndFormatQuery()
    {
        var topFilmsByGenre = GetTopFilmsByGenre(AllFilms);

        Console.WriteLine("--- Top 3 Films by Genre (Released 2020+) ---");
        Console.WriteLine(string.Join(Environment.NewLine, topFilmsByGenre));
    }
}
