using System;

public class Calculator
{
    // Programmanyň esasy bölümi, iş şu ýerden başlaýar
    public static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Ýönekeý hasaplaýjy");
        Console.WriteLine("---------------------------------------------");

        // Täzeden hasaplamak üçin açar (bool: dogry/ýalňyş)
        bool runAgain = true;

        // Ulanyjy 'exit' basýança amallary gaýtalamak
        while (runAgain)
        {
            Console.WriteLine("\nBirinji sany giriz ýa-da ('exit') bas:");
            string input1 = Console.ReadLine();

            if (input1.ToLower() == "exit")
            {
                break;
            }

            Console.WriteLine("Amaly giriz (+, -, *, /):");
            string operation = Console.ReadLine();

            Console.WriteLine("Ikinji sany giriz:");
            string input2 = Console.ReadLine();

            // Sanlary we netijäni saklaýan üýtgeýjiler
            double num1 = 0;
            double num2 = 0;
            double result = 0;
            bool success = true;


            // --- GIRIŞ Barlagy: San däl-de, harp girizilen bolsa barlamak ---
            // TryParse girizilen teksti sana öwürýär. Eger şowsuz bolsa, 'success' ýalňyş bolýar.
            bool input1Valid = double.TryParse(input1, out num1);
            bool input2Valid = double.TryParse(input2, out num2);

            // Eger sanlar dogry däl bolsa, ýalňyşlyk baradaky maglumaty görkezmeli
            if (!input1Valid || !input2Valid)
            {
                Console.WriteLine("\n--- YALNYS TUTULDY (San Formaty) ---");
                Console.WriteLine("Ýalňyşlyk: Girizilenler san däl. Haýyş, dogry sanlary giriziň.");
                Console.WriteLine("--------------------------------------------");
                success = false;
            }

            // --- TRY BLOKY: Ýalňyşlyk çykyp biljek kody synap görmek (diňe hasaplama) ---
            // Diňe sanlar dogry girizilen bolsa, hasaplaýjy bloga gir
            if (success)
            {
                try
                {
                    // Amaly (operatory) ýerine ýetirmek
                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            break;

                        case "-":
                            result = num1 - num2;
                            break;

                        case "*":
                            result = num1 * num2;
                            break;

                        case "/":
                            if (num2 == 0)
                            {
                                throw new DivideByZeroException("Nola bölüp bolmaýar! Başga san giriziň.");
                            }

                            result = num1 / num2;
                            break;

                        default:
                            Console.WriteLine("Duýduryş: Nädogry amal girizildi. Haýyş, +, -, *, ýa-da / ulanyň.");
                            success = false;
                            break;
                    }
                }
                // --- CATCH 1: Eger Nola Bölme (DivideByZero) ýalňyşlygy çyksa, ony tutmak ---
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Nola bölüp bolanok: {ex.Message}");
                    success = false;
                }
                // --- CATCH 2: Başga garşydaş ýalňyşlyklar üçin (Umumy Ýalňyşlyk) ---
                catch (Exception ex)
                {
                    Console.WriteLine($"Nätanyş ýalňyşlyk: {ex.Message}");
                    success = false;
                }
                // --- FINALLY BLOKY: Ýalňyşlyk bolsada, bolmasada hökman işleýän ýer ---
                finally
                {
                    Console.WriteLine("\n--- AHYRKY BLOK IŞLEDI ---");
                    if (success)
                    {
                        // Netije diňe hasaplama üstünlikli bolsa görkeziler
                        Console.WriteLine($"Netije: {num1} {operation} {num2} = {result:N2}");
                    }
                    else
                    {
                        Console.WriteLine("Ýüze çykan ýalňyşlyk sebäpli dogry netije görkezilmedi.");
                    }
                    Console.WriteLine("---------------------------------");
                }
            } // if (success) blogy ýapylýar

            // Ulanyjydan dowam etmek isleýändigini soramak
            Console.Write("\nBaşga hasaplama etmek üçin Enter basyň, ýa-da 'exit' ýazyp Enter basyň: ");
            if (Console.ReadLine().ToLower() == "exit")
            {
                runAgain = false;
            }
        } // while (runAgain) blogy ýapylýar

        Console.WriteLine("\nHasaplaýjyny ulananyňyz üçin sag boluň! Sag aman galyň.");
    } 
} 
