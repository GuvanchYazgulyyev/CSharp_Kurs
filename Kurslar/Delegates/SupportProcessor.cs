using System;
using System.Collections.Generic;
using System.Linq;



    // Define the Ticket structure
    public record Ticket(int Id, string Title, int Priority);

    public class SupportProcessor
    {
        // The main processing queue (FIFO)
        private static Queue<Ticket> RequestQueue = new Queue<Ticket>();
        // The rollback stack (LIFO)
        private static Stack<Ticket> RollbackStack = new Stack<Ticket>();

        // Initial list of tickets to load
        private static List<Ticket> InitialTickets = new List<Ticket>
        {
            new Ticket(101, "Server Down", 1),
            new Ticket(102, "VPN Access Issue", 2),
            new Ticket(103, "Password Reset", 3),
            new Ticket(104, "Printer Offline", 3),
            new Ticket(105, "Software Update Failed", 2),
            new Ticket(106, "Email Sync Error", 1)
        };

        public static void RunSupportProcess()
        {
            // Load all initial requests to the queue
            foreach (var ticket in InitialTickets)
            {
                RequestQueue.Enqueue(ticket);
            }
            Console.WriteLine($"Queue loaded with {RequestQueue.Count} requests.");

            // 1. Process the first three requests and push to the Stack
            ProcessAndPushToStack(3);

            // 2. Group the remaining requests in the queue by priority
            GroupRemainingRequestsByPriority();

            // 3. Show the last two transactions in the stack (LIFO)
            ShowLastTwoTransactions();
        }

        private static void ProcessAndPushToStack(int count)
        {
            Console.WriteLine("\n--- Processing and Rollback Setup ---");
            for (int i = 0; i < count; i++)
            {
                if (RequestQueue.TryDequeue(out Ticket ticket))
                {
                    // Remove from Queue (Processed)
                    Console.WriteLine($"Processed: ID {ticket.Id} - {ticket.Title}");

                    // Push to Stack for Rollback
                    RollbackStack.Push(ticket);
                }
            }
            Console.WriteLine($"\nRemaining items in Queue: {RequestQueue.Count}");
            Console.WriteLine($"Items in Rollback Stack: {RollbackStack.Count}");
        }

        private static void GroupRemainingRequestsByPriority()
        {
            Console.WriteLine("\n--- Remaining Requests Grouped by Priority ---");

            var groupedByPriority = RequestQueue
                // Group the remaining items by Priority
                .GroupBy(t => t.Priority)
                // Project the result into a readable format (Priority Level and Count)
                .Select(group => new
                {
                    PriorityLevel = group.Key,
                    Count = group.Count()
                })
                // Sort by Priority (lower number = higher priority)
                .OrderBy(result => result.PriorityLevel);

            foreach (var group in groupedByPriority)
            {
                Console.WriteLine($"Priority {group.PriorityLevel}: {group.Count} requests.");
            }
        }

        private static void ShowLastTwoTransactions()
        {
            Console.WriteLine("\n--- Last Two Transactions (Rollback Stack LIFO) ---");

            var lastTwo = RollbackStack
                // Stack enumerates LIFO, so Take(2) gets the two most recent pushes.
                .Take(2)
                // Project them into the required Id-Title format
                .Select(t => $"{t.Id} - {t.Title}");

            foreach (var transaction in lastTwo)
            {
                Console.WriteLine($"Rollback Item: {transaction}");
            }
        }
    }

    