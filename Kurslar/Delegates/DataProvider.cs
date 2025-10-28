using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Kurs.Kurslar.Delegates
{
    // Define client structure 
    public record Customer (int Id, string Name, string City);

    // Define the order structure (Corrected 'CostumerId' to 'CustomerId')
    public record Order(int CustomerId, double Amount);

    public static class DataProvider // Made static to hold static data
    {
        // Client dictionary (Dictionary: Id -> Customer)
        public static Dictionary<int, Customer> Customers { get; } = new Dictionary<int, Customer>
        {
            { 1, new Customer(1, "Aman A", "Ashgabat") },
            { 2, new Customer(2, "Bäşim B", "Mary") },
            { 3, new Customer(3, "Gülşat G", "Ashgabat") },
            { 4, new Customer(4, "Döwlet D", "Balkanabat") },
            { 5, new Customer(5, "Ene E", "Mary") }
        };

        // Zakazlaryn sanawy 
        public static List<Order> Orders { get; } = new List<Order>
        {
            new Order(1, 150.00), // Ashgabat
            new Order(3, 300.50), // Ashgabat
            new Order(2, 50.00),  // Mary
            new Order(5, 75.25),  // Mary
            new Order(4, 400.00), // Balkanabat
            new Order(1, 20.00),  // Ashgabat
            new Order(2, 10.00)   // Mary
        };

        /// <summary>
        /// Calculates and displays the total revenue per city using LINQ Method Syntax.
        /// </summary>
        public static void CalculateTotalCityRevenue()
        {
            Console.WriteLine("--- 1. Şäher boýunça Umumy Baha (Ciro) (Method Syntax) ---");

            var cityRevenueMethod = DataProvider.Orders
            // 1. JOIN: Birleşdirmek (Orders bilen Customers)
            .Join(
                DataProvider.Customers,           // Ikinji kolleksiýa
                order => order.CustomerId,        // Orders-daky açar
                customerKVP => customerKVP.Key,   // Customers-daky açar (Id)
                (order, customerKVP) => new { order, customer = customerKVP.Value }
            )
            // 2. GROUP BY: Şäher boýunça toparlamak
            .GroupBy(
                joined => joined.customer.City,   // Toparlamak açary (Şäher ady)
                (city, groupedOrders) => new
                {
                    City = city,                  // Şäher ady
                    // Toplanan sargytlar boýunça jemi bahany hasaplamak
                    TotalRevenue = groupedOrders.Sum(g => g.order.Amount)
                }
            )
            // 3. ORDER BY: Jemi Baha boýunça iň ulusyndan iň kiçisine çenli tertiplemek
            .OrderByDescending(result => result.TotalRevenue)
            // 4. SELECT: Netijäni saýlamak (optional here, but keeps the var name consistent)
            .Select(result => result); 

            // Output the results
            foreach (var item in cityRevenueMethod)
            {
                // Note: Using 'C2' for currency formatting, adjust as needed.
                Console.WriteLine($"{item.City}: {item.TotalRevenue:C2}");
            }
        }
    }
}