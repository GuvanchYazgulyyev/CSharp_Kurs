// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Calculator 
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Yonekey kalkulyator!");
        Console.WriteLine("---------------------");
        
        bool continueCalculating = true;

        while (continueCalculating) // Main loop runs until 'continueCalculating' is set to false
        {
            try 
            {
                // --- Input 1 ---
                Console.WriteLine("\nBirinji sany girizin ('exit' basyp bilersiniz):");
                string input1String = Console.ReadLine()?.ToLower();
                
                if (input1String == "exit")
                {
                    continueCalculating = false;
                    Console.WriteLine("Kalkulyator yatyrdy. Sagbol!");
                    break;
                }

                // --- Operation ---
                Console.WriteLine("Amallary girizi: ('+','-','*','/') yada 'exit' basyn:");
                string operation = Console.ReadLine()?.ToLower();
                
                if (operation == "exit")
                {
                    continueCalculating = false;
                    Console.WriteLine("Kalkulyator yatyrdy. Sagbol!");
                    break;
                }

                // --- Input 2 ---
                Console.WriteLine("Ikinji sany girizin ('exit' basyp bilersiniz):");
                string input2String = Console.ReadLine()?.ToLower();
                
                if (input2String == "exit")
                {
                    continueCalculating = false;
                    Console.WriteLine("Kalkulyator yatyrdy. Sagbol!");
                    break;
                }
                
                // --- Parsing Section ---
                // If we reach here, we know the inputs are not "exit", so we can parse them.
                int input1 = int.Parse(input1String!);
                int input2 = int.Parse(input2String!);
                
                int result = 0; // Initialize result

                // --- Calculation Section with Switch and Error Handling ---
                switch (operation)
                {
                    case "+":
                        result = input1 + input2;
                        break;
                    case "-":
                        result = input1 - input2;
                        break;
                    case "*":
                        result = input1 * input2;
                        break;
                    case "/":
                        try
                        {
                            result = input1 / input2;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Yalnyshlyk: Nola bolup bolanok! Netije 0.");
                            result = 0;
                        }
                        break;
                    default:
                        Console.WriteLine($"Nadogry amal '{operation}'. Gaytadan synanyshyn. Amallar ('+,-,*,/') bolmaly");
                        continue; // Skip result display and jump to the next loop iteration
                }
                
                // --- Output Section ---
                Console.WriteLine($"Netije: {result}"); 
            }
            catch (FormatException)
            {
                Console.WriteLine("yalnyshlyk : Diñe san girizmeli. Gaýtadan synanyshyn.");
            }
            catch (Exception ex)
            {
                 // Catches any other unexpected errors
                Console.WriteLine($"Name-de bolsa yalnys bar: {ex.Message}");
            }
        }
    }
}
